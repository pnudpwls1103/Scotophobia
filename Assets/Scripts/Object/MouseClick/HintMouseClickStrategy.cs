using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintMouseClickStrategy : ClickStrategy
{   
    override public void ClickMethod(PointerEventData eventData)
    {
        eventData.pointerPressRaycast.gameObject.SetActive(false);
    }
}
