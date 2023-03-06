using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightTest : MonoBehaviour
{
    Light2D lit;
    Coroutine co;
    public static event System.Action OnFadeIn = null;
    public float defLight = 0.4f;
    public float speed = 0.002f;
    public bool isCor = false;
    void Start()
    {
        lit = GetComponent<Light2D>();
        PlayerTest.OnBulbOn += OnBulbOn;
        PlayerTest.OnBulbOff += OnBulbOff;
    }

    void Update()
    {
        
    }

    void OnBulbOn()
    {
        lit.intensity = 0.1f;
        if (co != null)
        {
            StopCoroutine(co);
            co = null;
        }
    }
    void OnBulbOff()
    {
        if(isCor)
            co = StartCoroutine(FadeIn());
        else {
            lit.intensity = 0.2f;
        }
    }

    public void SetIntensity(float intensity)
    {
        lit.intensity = intensity;
    }

    public void SetColor(Color color)
    {
        lit.color = color;
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.2f);
        while (lit.intensity < defLight)
        {
            lit.intensity += speed;
            yield return null;
        }
        if (OnFadeIn != null)
            OnFadeIn();
    }
}
