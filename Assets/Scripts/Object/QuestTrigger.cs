using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : Trigger
{   
    override public void Interact(GameObject gameObject)
    {
        if(isActivate)
        {
            Action(gameObject);
        }
    }
    override public void Action(GameObject player)
    {
        GameManager.Instance.questManager.CheckQuest();
    }
}
