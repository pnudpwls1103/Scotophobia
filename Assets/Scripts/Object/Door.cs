using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteraction
{
    public void Interact(GameObject gameObject)
    {
        int objectNum  = GetComponent<ObjectData>().id;
        string sceneName = this.gameObject.name.Substring(4);
        if(GameManager.stageNumber == objectNum)
            SceneManager.LoadScene(sceneName);
    }
}
