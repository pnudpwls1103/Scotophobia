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
        talkData.Add(1000, new string[]{"부엌"});
        talkData.Add(2000, new string[]{"아빠 서재"});
        talkData.Add(3000, new string[]{"열쇠"});

        talkData.Add(1000 + 10, new string[]{"부엌", "여기는 집안일 퍼즐이 있는 곳이다."});
        talkData.Add(2000 + 10, new string[]{"아빠 서재", "여기는 책 퍼즐이 있는 곳이다."});

        talkData.Add(1000 + 20, new string[]{"무언가의 힘에 의해 문이 열렸다.", "집안일 퍼즐을 풀어봐야할거 같다.", "참깨빵 위에 순쇠고기 패티 두장", "특별한 소스 양상추", "치즈 피클 양파 까아지"});
        
        talkData.Add(3000 + 20 + 1, new string[]{"열쇠를 찾았다."});
        
        talkData.Add(2000 + 30, new string[]{"작은 옷장이다", "옷장을 보니 편안한 마음이 든다.", "옷장에 뭔가가 있다?"});
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
