using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookPuzzle : ObjectData
{
    [SerializeField]
    CuttingBoard cuttingBoard;
    [SerializeField]
    FryingPan fryingPan;

    void Start()
    {
        GameManager.Instance.globalLight.SetIntensity(1f);
    }

    public void Clear()
    {
        GameManager.Instance.questManager.CheckQuest();
        GameManager.Instance.globalLight.SetIntensity(0.7f);
        Debug.Log("Cook Puzzle Clear");
    }
}
