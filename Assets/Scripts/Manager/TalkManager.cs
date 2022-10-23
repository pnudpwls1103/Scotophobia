using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        //  x000 : 오브젝트 - scanObject에서 얻어오기
        //   x0 : 퀘스트 - QuestManager에서 얻어오기
        talkData.Add(0, new string[]{"미션을 수행하세요"});

        talkData.Add(10000, new string[]{"부엌"});
        talkData.Add(20000, new string[]{"복도"});
        talkData.Add(30000, new string[]{"아빠 서재"});
        talkData.Add(40000, new string[]{"세탁실"});

        talkData.Add(10000 + 1000 + 10, new string[]{"조리공간 위에 재료들이 있다."});
        talkData.Add(10000 + 2000 + 10 + 1, new string[]{"방금 만들어서 따끈따끈한 샌드위치를 먹었다."});
        
        talkData.Add(1000 + 10, new string[]{"부엌", "여기는 집안일 퍼즐이 있는 곳이다."});
        talkData.Add(2000 + 10, new string[]{"아빠 서재", "여기는 책 퍼즐이 있는 곳이다."});

        
    }

    public string GetTalk(int id, int talkIndex)
    {
        // 퀘스트 id에서 퀘스트 index에 해당하는 대사가 없는 경우
        if(!talkData.ContainsKey(id))
        {
            // 기본 대사 출력
            if(!talkData.ContainsKey(id - id%10))
                return GetTalk(id - id%100, talkIndex);
            else
                return GetTalk(id - id%10, talkIndex);
            
        }

        // 퀘스트 id에서 퀘스트 index에 해당하는 대사가 있는 경우
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    
}
