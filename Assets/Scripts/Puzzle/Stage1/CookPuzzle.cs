using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPuzzle : ObjectData
{
    [SerializeField]
    CuttingBoard cuttingBoard;
    [SerializeField]
    FryingPan fryingPan;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Clear()
    {
        Debug.Log("Cook Puzzle Clear");
    }
}
