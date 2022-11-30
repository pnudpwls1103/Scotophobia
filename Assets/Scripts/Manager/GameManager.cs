using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

enum Room 
{
    Hall = 60000,
    Kitchen = 10000,
    Library = 20000,
    Laundry = 30000,
}
public class GameManager : MonoBehaviour
{
    // 스테이지/시계
    [SerializeField]
    Sprite[] clockSprites;
    public Image clockImage;
    int limitStage;
    public int LimitStage
    {
        get
        {
            return limitStage;
        }
        set
        {
            limitStage = value;
            clockImage.sprite = clockSprites[limitStage / 10000 - 1];
        }

    }
    int currentStage;
    public int CurrentStage
    {
        get
        {
            return currentStage;
        }
        set
        {
            currentStage = value;
        }
    }

    public GlobalLight globalLight;
    public QuestManager questManager;
    public TalkManager talkManager;
    public DoorManager doorManager;
    public CutSceneManager cutSceneManager;
    public LineManager lineManager;
    public LifeManager lifeManager;

    // 대화/대사창
    public GameObject talkPanel;
    public Text UIText;
    public Text UINameText;
    public GameObject scanObject;
    public bool isAction = false;
    public bool isLineActive = false;
    public int lineNumber = 1;

    public GameObject player;
    public GameObject mainCamera;
    public Fade fadeImage;
    public GameObject gameOverUI;
    
    // 싱글톤
    private static GameManager _instance;
    public static GameManager Instance
    {
        get 
        {
            if(!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if(_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        // DontDestroyOnLoad(questManager);
        // DontDestroyOnLoad(talkManager);
        DontDestroyOnLoad(GameObject.Find("UICanvas"));
        // DontDestroyOnLoad(GameObject.Find("GlobalLight"));
        // DontDestroyOnLoad(GameObject.Find("Player"));
    }

    void Start()
    {
        clockImage.gameObject.SetActive(false);
        talkPanel.SetActive(isAction);
        currentStage = (int)Room.Hall;
        limitStage = (int)Room.Kitchen;
        questManager.questId = 0;
        doorManager.SetActivate();

        lifeManager.SetUI(false);
        questManager.CheckQuest();
        Time.timeScale = 0f;
    }

    public void Action(GameObject scanObj)
    {
        if(scanObj != null && !isLineActive)
        {
            scanObject = scanObj;
            ObjectData objData = scanObject.GetComponent<ObjectData>();
            Talk(objData.id);
        } 
        else if(isLineActive)
        {
            PrintLine();
        }
        
        talkPanel.SetActive(isAction);
        UINameText.gameObject.SetActive(isLineActive);
    }

    void Talk(int id)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex();
        string talkData;
        if(id/10000 > 0)
            talkData = talkManager.GetTalk(id);
        else
            talkData = talkManager.GetTalk(currentStage + id + questTalkIndex);

        if(talkData == null)
        {
            if(currentStage == 20000 && id == 3000 && questManager.questId == 80)
            {
                questManager.CheckQuest();
            }
            isAction = false;
            talkManager.talkIndex = 0;
            return;
        }

        UIText.text = talkData;
        
        isAction = true;
        talkManager.talkIndex++;
    }

    public void ControlSceneObject(bool playerState, bool cameraState)
    {
        player.SetActive(playerState);
        mainCamera.SetActive(cameraState);
    }

    public void SetLineQueue()
    {
        isLineActive = true;
        lineManager.ClearLineQueue();
        lineManager.SetLines(lineNumber);
    }
    public void PrintLine()
    {
        Tuple<string, string> lineData = lineManager.GetLine();

        if(lineData == null)
        {
            if(questManager.questId == 20 || questManager.questId == 70)
            {
                questManager.CheckQuest();
            }
            
            isAction = false;
            isLineActive = false;

            return;
        }

        UINameText.text = lineData.Item1;
        UIText.text = lineData.Item2;

        isAction = true;
        lineManager.lineIndex++;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}