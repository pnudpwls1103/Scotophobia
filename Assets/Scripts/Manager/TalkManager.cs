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
        talkData.Add(100, new string[]{"주방이다.", "배고프다.", "나도 배고프다"});
        talkData.Add(300, new string[]{"아빠가 그려진 사진조각이다.", "왜 사진조각만 떨어져 있는거지?"});
    }

    public string GetTalk(int objectId, int talkIndex)
    {
        if(talkIndex == talkData[objectId].Length)
            return null;
        else
            return talkData[objectId][talkIndex];
    }

}
