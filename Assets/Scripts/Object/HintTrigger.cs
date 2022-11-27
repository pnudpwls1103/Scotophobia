using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintTrigger : Trigger
{
    [SerializeField]
    Image hintImage;
    public Sprite image = null;
    override public void Interact(GameObject gameObject)
    {
        if(isActivate)
        {
            Action(gameObject);
        }
    }

    override public void Action(GameObject player)
    {
        PlayerController playerController = GameManager.Instance.player.GetComponent<PlayerController>();
        if(!hintImage.gameObject.activeSelf)
        {
            playerController.canMove = false;
            playerController.canClick = false;
            
            hintImage.sprite = image;
            hintImage.gameObject.SetActive(true);
        }
    }


}
