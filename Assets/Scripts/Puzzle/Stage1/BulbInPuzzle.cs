using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BulbInPuzzle : MonoBehaviour, IPointerClickHandler
{
    int x, y; // 본인의 위치 좌표
    public event Action<int, int> OnClickBulb;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickBulb(x, y);
    }

    void Start()
    {
        string str = gameObject.name;
        int val = int.Parse(str.Substring(4));
        x = val / 4;
        y = val % 4;
    }
}
