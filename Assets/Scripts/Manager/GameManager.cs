using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stageNumber;
    public QuestManager questManager;
    public TalkManager talkManager;

    // 대화창
    public GameObject talkPanel;
    public Text UITalkText;
    public GameObject scanObject;
    public bool isAction = false;
    public int talkIndex;

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
    }

    public void Start()
    {
        talkPanel.SetActive(isAction);
        questManager.CheckQuest();
        stageNumber = 10000;
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


    public void ChangeNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        talkPanel = GameObject.Find("UI_talk");
        UITalkText = GameObject.Find("Talk").GetComponentInChildren<Text>();
        Debug.Log(scene.name);
    }

    void Talk(int id)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        UITalkText.text = talkData;
        
        isAction = true;
        talkIndex++;
    }

}