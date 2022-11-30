using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : Trigger
{
    public Fade fade;
    public Transform nextPos;

    override public void Interact(GameObject gameObject)
    {
        if(isActivate)
        {
            fade.PlayFadeIn();
            Action(gameObject);
            GameManager.Instance.CurrentStage = id;
        }
    }

    override public void Action(GameObject player)
    {
        player.transform.position = nextPos.position;
    }
}
