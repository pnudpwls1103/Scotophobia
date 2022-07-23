using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm
{
    float currentTime;
    float changeTime;
    float minTime;
    float maxTime;
    public Alarm(float minTime, float maxTime)
    {
        this.minTime = minTime;
        this.maxTime = maxTime;
    }

    public bool IsTimeToEvent()
    {
        return (currentTime > changeTime);
    }

    public void TimeGoes()
    {
        currentTime += Time.deltaTime;
    }

    public void InitCurTime(float cutTime = 0f)
    {
        changeTime = Random.Range(minTime - cutTime, maxTime - cutTime);
        currentTime = 0f;
    }
}
