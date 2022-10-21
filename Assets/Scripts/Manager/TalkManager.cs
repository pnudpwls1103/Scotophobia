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
        // x000 : 스테이지
        // x00 : 오브젝트
        talkData.Add(1000, new string[]{"부엌", "여기는 집안일 퍼즐이 있는 곳이다."});
        talkData.Add(2000, new string[]{"아빠 서재", "여기는 책 퍼즐이 있는 곳이다."});
    }

    public string GetTalk(int objectId, int talkIndex)
    {
        if(talkIndex == talkData[objectId].Length)
            return null;
        else
            return talkData[objectId][talkIndex];
    }

}
