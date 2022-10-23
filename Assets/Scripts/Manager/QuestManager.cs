using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        questList.Add(10, new QuestData("시작", new int[]{2000}));
        questList.Add(20, new QuestData("집안일 수행하기", new int[]{1000, 3000}));
    }

    // Object의 Id를 받아 퀘스트 번호를 반환하는 함수
    public int GetQuestTalkIndex(int id)
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

            if(questOrderIndex == questList[questId].objectId.Length)
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
                    questObject[0].SetActive(true);
                break;
            
            case 20:
                if(questOrderIndex == 2)
                    questObject[0].SetActive(false);
                break;
            default:
                break;
        }
    }
}
