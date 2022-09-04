using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PicturePiece : MonoBehaviour, IPointerClickHandler
{
    public event Action<float, float> OnClick = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClick != null)
            OnClick(transform.localPosition.y, transform.localPosition.x);
    }
}