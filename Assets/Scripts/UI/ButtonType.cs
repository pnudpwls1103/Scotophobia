using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
                SceneManager.sceneLoaded += LoadedStartEvent;
                SceneManager.LoadScene("Hall", LoadSceneMode.Additive);
                break;
            case BTNType.Load:
                GameObject.Find("MenualCanvas").GetComponentInChildren<Image>(true).gameObject.SetActive(true);
                break;
            case BTNType.Option:
                Debug.Log("Option");
                break;
            case BTNType.Quit:
                Application.Quit();
                break;
            case BTNType.StartEnd:
                Destroy(GameObject.Find("GameManager"));
                SceneManager.sceneLoaded += LoadedEndEvent;
                SceneManager.LoadScene("Start", LoadSceneMode.Additive);
                break;
            case BTNType.StartTemp:
                Destroy(GameObject.Find("GameManager"));
                SceneManager.sceneLoaded += LoadedTempEvent;
                SceneManager.LoadScene("Start", LoadSceneMode.Additive);
                break;
        }
    }

    void LoadedStartEvent(Scene scene, LoadSceneMode mode)
    {
        SceneManager.UnloadSceneAsync("Start");
        SceneManager.sceneLoaded -= LoadedStartEvent;
    }

    void LoadedEndEvent(Scene scene, LoadSceneMode mode)
    {
        SceneManager.UnloadSceneAsync("End");
        SceneManager.sceneLoaded -= LoadedEndEvent;
    }

    void LoadedTempEvent(Scene scene, LoadSceneMode mode)
    {
        SceneManager.UnloadSceneAsync("Temp");
        SceneManager.sceneLoaded -= LoadedTempEvent;
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
