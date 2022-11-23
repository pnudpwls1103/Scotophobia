using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonType : MonoBehaviour
{
    public BTNType currentType;
    public void OnButtonClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                SceneManager.sceneLoaded += LoadedsceneEvent;
                SceneManager.LoadScene("Hall", LoadSceneMode.Additive);
                break;
            case BTNType.Quit:
                Application.Quit();
                break;
        }
    }

    void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        SceneManager.UnloadSceneAsync("Start");
        SceneManager.sceneLoaded -= LoadedsceneEvent;
    }
}
