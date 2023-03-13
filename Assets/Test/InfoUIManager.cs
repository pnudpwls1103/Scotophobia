using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject go_InfoUI;
    [SerializeField]
    private TMPro.TextMeshProUGUI infoText;

    private bool isTypingEffect = false;

    void Start()
    {
        DisableInfoUI();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bool isOpen = go_InfoUI.activeSelf == true;
            if(isOpen && isTypingEffect == false)
            {
                DisableInfoUI();
            }
        }
        
    }

    public void EnableInfoUI()
    {
        go_InfoUI.SetActive(true);
    }

    public void DisableInfoUI()
    {
        go_InfoUI.SetActive(false);
    }

    public void SetInfoText(string _text)
    {
        infoText.text = "";
        StartCoroutine(TypingText(0, _text));
    }

    private IEnumerator TypingText(int idx, string _message) 
    { 
        isTypingEffect = true;
        for (int i = 0; i < _message.Length; i++) 
        { 
            infoText.text += _message[i];
            yield return new WaitForSeconds(0.1f); 
        } 
        isTypingEffect = false;
    }
}
