using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTrigger : Trigger
{
    public int stageNum;
    public string SceneName;
    public GameObject HideObject;
    override public void Interact(GameObject gameObject)
    {
        if(isActivate)
        {
            Action(gameObject);
            GameManager.Instance.Stage = stageNum;
        }
    }

    override public void Action(GameObject player)
    {
        GameManager.Instance.ControlSceneObject(false, false);
        HideObject.SetActive(false);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }

    public void Restore()
    {
        GameManager.Instance.ControlSceneObject(true, true);
        HideObject.SetActive(true);
        SceneManager.UnloadSceneAsync(SceneName);
    }
}
