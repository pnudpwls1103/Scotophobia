using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
            case BTNType.Load:
                Debug.Log("Load");
                break;
            case BTNType.Option:
                Debug.Log("Option");
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentsInChildren<TMP_Text>()[0].fontStyle = FontStyles.Bold;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentsInChildren<TMP_Text>()[0].fontStyle = FontStyles.Normal;
    }
}
