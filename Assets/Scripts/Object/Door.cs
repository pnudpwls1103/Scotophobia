using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : Trigger
{
    public Fade fade;
    public Transform nextPos;

    void Awake()
    {
        fade = GameObject.Find("Fade").GetComponent<Fade>();  
    }

    override public void Interact(GameObject gameObject)
    {
        if(isActivate)
        {
            fade.PlayFadeIn();
            Action(gameObject);
            GameManager.Instance.Stage = id;
        }
    }

    override public void Action(GameObject player)
    {
        player.transform.position = nextPos.position;
    }
}
