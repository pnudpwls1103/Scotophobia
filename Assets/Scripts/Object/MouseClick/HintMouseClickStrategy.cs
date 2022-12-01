using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintMouseClickStrategy : ClickStrategy
{   
    public GameObject hindObject;
    override public void ClickMethod(PointerEventData eventData)
    {
        hindObject.SetActive(false);
    }
}
