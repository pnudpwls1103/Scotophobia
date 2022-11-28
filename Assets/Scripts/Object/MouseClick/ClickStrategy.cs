using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ClickStrategy : MonoBehaviour
{
    public abstract void ClickMethod(PointerEventData eventData);

}
