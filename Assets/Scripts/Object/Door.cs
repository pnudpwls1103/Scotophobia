using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Trigger
{
    public Transform nextPos;

    override public void Interact(GameObject gameObject)
    {
        if(isActivate)
        {
            Action(gameObject);
            GameManager.Instance.Stage = id;
        }
    }

    override public void Action(GameObject player)
    {
        player.transform.position = nextPos.position;
    }
}
