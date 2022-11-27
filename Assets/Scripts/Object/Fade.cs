using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float animTime = 2f;         
    private Image fadeImage;            

    private float START = 1f;           
    private float END = 0f;             
    private float time = 2f;            

    void Awake()  
    {   
        fadeImage = GetComponent<Image>();  
        PlayFadeIn();
    }  

    public void PlayFadeIn()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()  
    {   
        time = 0f;
        Color color = fadeImage.color;  
        color.a = 1f;

        while(color.a > 0f)
        {
            time += Time.deltaTime / animTime;  
            
            color.a = Mathf.Lerp(START, END, time);    
            fadeImage.color = color;  
            yield return null;
        }
    }  

    void FadeOut()  
    {   
        time += Time.deltaTime / animTime;  
 
        Color color = fadeImage.color;  
        color.a = Mathf.Lerp(END, START, time); 
        fadeImage.color = color;  
    }
}
