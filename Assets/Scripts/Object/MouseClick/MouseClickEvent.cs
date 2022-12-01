using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickEvent : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    ClickStrategy clickStrategy;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.Instance != null)
        {
            PlayerController playerController = GameManager.Instance.player.GetComponent<PlayerController>();
            playerController.canMove = true;
            playerController.canClick = true;
        }
        
        clickStrategy.ClickMethod(eventData);
    }
}
