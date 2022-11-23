using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LockPuzzle : MonoBehaviour
{
    [Serializable]
    class OneUnitInfo
    {
        public LockOneUnit oneUnit;
        public int goal;
    }
    [SerializeField]
    List<OneUnitInfo> oneUnitInfos = new List<OneUnitInfo>();

    private void Update()
    {
        if (CheckClear())
        {
            GameManager.Instance.questManager.CheckQuest();
            Debug.Log("Clear");
        }
            
    }
    bool CheckClear()
    {
        foreach (OneUnitInfo info in oneUnitInfos)
            if (info.goal != info.oneUnit.CurrentNum)
                return false;
        return true;
    }
}
