using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickEvent : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.Instance.questManager.questId == 10 && eventData.button == PointerEventData.InputButton.Left)
        {
            GameManager.Instance.questManager.CheckQuest();
        }
    }
}
