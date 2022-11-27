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
    public bool isCameraActive = false;
    public Sprite image = null;

    override public void Interact(GameObject gameObject)
    {
        if(isActivate)
        {
            SceneManager.sceneLoaded += LoadedsceneEvent;
            Action(gameObject);
            GameManager.Instance.Stage = stageNum;
        }
    }

    void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        if(image != null)
        {
            Time.timeScale = 0f;
            GameManager.Instance.SetImage(image);
        }
    }

    override public void Action(GameObject player)
    {
        GameManager.Instance.ControlSceneObject(isPlayerActive, isCameraActive);
        HideObject.SetActive(false);

        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }

    public void Restore()
    {
        Time.timeScale = 1f;
        GameManager.Instance.ControlSceneObject(true, true);
        HideObject.SetActive(true);
        SceneManager.UnloadSceneAsync(SceneName);
        SceneManager.sceneLoaded -= LoadedsceneEvent;
    }
}
