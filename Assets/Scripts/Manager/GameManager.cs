using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

enum Room 
{
    Hall = 60000,
    Kitchen = 10000,
    Library = 20000,
    Laundry = 30000,
}
public class GameManager : MonoBehaviour
{
    public int limitStage;
    public int currentStage;
    public int Stage
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

    // 대화창
    public GameObject talkPanel;
    public Text UIText;
    public GameObject scanObject;
    public bool isAction = false;

    // 자동 대사
    public bool isLineActive = false;
    public int lineNumber = 1;
    // Player
    public GameObject player;
    

    // Camera
    public GameObject mainCamera;
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

    public void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        talkPanel = GameObject.Find("UI_talk");
        UIText = GameObject.Find("Talk").GetComponentInChildren<Text>();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(questManager);
        DontDestroyOnLoad(talkManager);
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(GameObject.Find("GlobalLight"));
        DontDestroyOnLoad(GameObject.Find("Player"));
    }

    public void Start()
    {
        talkPanel.SetActive(isAction);
        currentStage = (int)Room.Hall;
        limitStage = (int)Room.Kitchen;
        questManager.questId = 10;
        doorManager.SetActivate();

        SetLineQueue();
        Action(null);
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
        
        //대화창 활성화 상태에 따라 대화창 활성화 변경
        talkPanel.SetActive(isAction); 
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
        string lineData = lineManager.GetLine();

        if(lineData == null)
        {
            isAction = false;
            isLineActive = false;

            return;
        }

        UIText.text = lineData;

        isAction = true;
        lineManager.lineIndex++;
    }
}