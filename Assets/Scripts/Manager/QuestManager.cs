using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int questId; // 현재 퀘스트 Id
    Dictionary<int, QuestData> questList;
    public GameObject[] questObject;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("샌드위치 만들기", new int[]{1000}));
        questList.Add(20, new QuestData("책 배열", new int[]{3000}));
        questList.Add(30, new QuestData("공 뽑기", new int[]{5000}));
    }

    public void SetQuestClear(int questid)
    {
        questList[questId].cleared = true;
    }

    // Object의 Id를 받아 퀘스트 번호를 반환하는 함수
    public int GetQuestTalkIndex()
    {
        return questId;
    }

    public string CheckQuest()
    {
        if(questList.ContainsKey(questId))
        {
            ControlObject();

            if(questList[questId].cleared)
                NextQuest();
            
            if(questList.ContainsKey(questId))
                return questList[questId].questName;
        }

        return null;
    }

    void NextQuest()
    {
        questId += 10;
    }

    void ControlObject()
    {
        PuzzleTrigger trigger;
        switch(questId)
        {
            case 10:
                questList[questId].cleared = true;
                GameManager.Instance.limitStage = 20000;
                GameManager.Instance.doorManager.SetActivate();
                trigger = questObject[0].GetComponent<PuzzleTrigger>();
                trigger.Restore();
                trigger.isActivate = false;
                break;
            case 20:
                questList[questId].cleared = true;
                GameManager.Instance.doorManager.SetActivate();
                trigger = questObject[1].GetComponent<PuzzleTrigger>();
                trigger.Restore();
                trigger.isActivate = false;
                break;
            default:
                break;
        }
    }
}