using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTrigger : Trigger
{
    public int stageNum;
    public string SceneName;
    public GameObject HideObject;
    public bool isPlayerActive = false;

    override public void Interact(GameObject gameObject)
    {
        if(isActivate)
        {
            Action(gameObject);
            GameManager.Instance.CurrentStage = stageNum;
        }
    }

    override public void Action(GameObject player)
    {
        HideObject.SetActive(false);
        if(isPlayerActive)
        {
            PlayerController playerController = GameManager.Instance.player.GetComponent<PlayerController>();
            playerController.canMove = false;
            playerController.canClick = false;
        }
        
        GameManager.Instance.eventsystem.SetActive(false);
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }

    public void Restore()
    {
        GameManager.Instance.ControlSceneObject(true, true);
        PlayerController playerController = GameManager.Instance.player.GetComponent<PlayerController>();
        playerController.canMove = true;
        playerController.canClick = true;
        HideObject.SetActive(true);
        GameManager.Instance.eventsystem.SetActive(true);
        SceneManager.UnloadSceneAsync(SceneName);
    }
}
