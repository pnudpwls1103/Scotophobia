using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    List<int> talkIds;
    Dictionary<int, string[]> talkData;
    public int talkIndex = 0;
    void Awake()
    {
        talkIds = new List<int>();
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        //  x000 : 오브젝트 - scanObject에서 얻어오기
        //   x0 : 퀘스트 - QuestManager에서 얻어오기
        talkData.Add(0, new string[]{"미션을 수행하세요"});

        talkData.Add(10000, new string[]{"부엌"});
        talkData.Add(20000, new string[]{"아빠 서재"});
        talkData.Add(30000, new string[]{"세탁실"});

        talkData.Add(60000, new string[]{"복도"});

        talkData.Add(10000 + 1000, new string[]{"조리공간이다."});
        talkData.Add(10000 + 1000 + 20, new string[]{"조리공간 위에 재료들이 있다."});
        
        talkData.Add(20000 + 1000, new string[]{"아빠의 책이 가득 찬 책장이다."});
        talkData.Add(20000 + 1000 + 20, new string[]{"이상한 문양이 그려진 책들이 있다."});

        talkData.Add(20000 + 2000, new string[]{"아빠와 함께 있는 사진이다."});
        talkData.Add(20000 + 2000 + 30, new string[]{"아빠와 함께 있는 사진이다."});

        foreach(int key in talkData.Keys)
            talkIds.Add(key);
    }

    public string GetTalk(int id)
    {
        if(!(talkIds.Contains(id) || talkIds.Contains(id - id%10) || talkIds.Contains(id - id%100)))
            return null;
        // 퀘스트 id에서 퀘스트 index에 해당하는 대사가 없는 경우
        if(!talkData.ContainsKey(id))
        {
            // 기본 대사 출력
            if(!talkData.ContainsKey(id - id%10))
            {
                return GetTalk(id - id%100);
            }
                
            else
                return GetTalk(id - id%10);
        }

        // 퀘스트 id에서 퀘스트 index에 해당하는 대사가 있는 경우
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
