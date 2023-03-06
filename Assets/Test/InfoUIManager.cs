using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoUIManager : MonoBehaviour
{
    public RectTransform infoUIImageParent;
    private GameObject imageGo;
    void Start()
    {
        imageGo = infoUIImageParent.GetChild(0).gameObject;
        DisableUI();
    }

    public void EnableUI()
    {
        imageGo.SetActive(true);
    }

    public void DisableUI()
    {
        imageGo.SetActive(false);
    }

    public void SetInfoText(string text)
    {

        TextMeshProUGUI textMeshPro = imageGo.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMeshPro.SetText(text);
    }
}
