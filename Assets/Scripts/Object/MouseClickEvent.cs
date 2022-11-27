using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickEvent : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            PlayerController playerController = GameManager.Instance.player.GetComponent<PlayerController>();
            playerController.canMove = true;
            playerController.canClick = true;
            this.gameObject.SetActive(false);
        }
    }
}
