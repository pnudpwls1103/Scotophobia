using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Book : MonoBehaviour
{
    public event Action<int> onBookClicked = null;
    int currentIdx;
    public int CurrentIdx { get { return currentIdx; } set { currentIdx = value; } }
    public void OnMouseDown()
    {
        Debug.Log($"idx : {currentIdx}");
        onBookClicked(currentIdx);
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
