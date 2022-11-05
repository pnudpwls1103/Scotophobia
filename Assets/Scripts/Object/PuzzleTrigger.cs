using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTrigger : Trigger
{
    public string SceneName;
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
        SceneManager.LoadScene(SceneName);
    }
}
