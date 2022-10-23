using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int questId; // 현재 퀘스트 Id
    public int questOrderIndex; // 퀘스트 내부 순서 인덱스
    Dictionary<int, QuestData> questList;
    public GameObject[] questObject;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("샌드위치 만들기", new int[]{1000, 2000}));
        questList.Add(20, new QuestData("책 배열", new int[]{3000, 4000}));
        questList.Add(30, new QuestData("공 뽑기", new int[]{5000, 6000}));
    
    }

    public void SetQuestClear(int questid)
    {
        questList[questId].cleared = true;
    }

    // Object의 Id를 받아 퀘스트 번호를 반환하는 함수
    public int GetQuestTalkIndex()
    {
        return questId + questOrderIndex;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    public string CheckQuest(int id)
    {   
        if(questList.ContainsKey(questId))
        {
            if(id == questList[questId].objectId[questOrderIndex])
                questOrderIndex++;

            ControlObject();

            bool clear = questList[questId].cleared;
            if(questOrderIndex == questList[questId].objectId.Length && clear)
                NextQuest();
        
            if(questList.ContainsKey(questId))
                return questList[questId].questName;
        }

        return null;

    }

    void NextQuest()
    {
        questId += 10;
        questOrderIndex = 0;
    }

    void ControlObject()
    {
        switch(questId)
        {
            case 10:
                if(questOrderIndex == 1)
                    
                    Debug.Log("Stage1_Puzzle 실행");
                    //GameManager.Instance.ChangeNextScene("Stage1_Puzzle");
                break;
            
            case 20:
                if(questOrderIndex == 1)
                    Debug.Log("Stage2_Puzzle1 실행");
                    //GameManager.Instance.ChangeNextScene("Stage2_Puzzle1");
                break;
            case 30:
                if(questOrderIndex == 1)
                {
                    Debug.Log("Stage2_Puzzle2 실행");
                    GameManager.Instance.ChangeNextScene("Stage2_Puzzle2");
                }
                    
                if(questOrderIndex == 2)
                {
                    Debug.Log("Stage2 실행");
                    GameManager.Instance.ChangeNextScene("Stage2");
                }
                break;
            default:
                break;
        }
    }
}
