using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BulbInPuzzle : MonoBehaviour, IPointerClickHandler
{
    const int MAXSIZE = 4;
    int x, y;
    public event Action<int, int> OnClickBulb;
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickBulb(x, y);
    }

    void Start()
    {
        string str = gameObject.name;
        int val = int.Parse(str.Substring(4));
        x = val / MAXSIZE;
        y = val % MAXSIZE;
    }
}
