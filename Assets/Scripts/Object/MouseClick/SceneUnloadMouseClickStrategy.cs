using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneUnloadMouseClickStrategy : ClickStrategy
{
    public string sceneName;
    override public void ClickMethod(PointerEventData eventData)
    {
        GameManager.Instance.eventsystem.SetActive(true);
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
