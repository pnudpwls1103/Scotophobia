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
            //puzzleManager.checkManager();
        }
    }

    public QuestManager questManager;
    public TalkManager talkManager;
    public PuzzleManager puzzleManager;

    // 대화창
    public GameObject talkPanel;
    public Text UITalkText;
    public GameObject scanObject;
    public bool isAction = false;

    // Player
    public GameObject player;
    public Vector3 playerPos;

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
        UITalkText = GameObject.Find("Talk").GetComponentInChildren<Text>();

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
        questManager.CheckQuest();
        currentStage = (int)Room.Hall;
        limitStage = (int)Room.Kitchen;
        questManager.questId = 10;
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id);
        
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

        UITalkText.text = talkData;
        
        isAction = true;
        talkManager.talkIndex++;
    }
}