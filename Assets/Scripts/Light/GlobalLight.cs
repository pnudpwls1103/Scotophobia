using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLight : MonoBehaviour
{
    Light2D lit;
    float defLight = 0.4f;
    float speed = 0.0002f;
    Coroutine co;
    public static event System.Action OnFadeIn = null;
    void Start()
    {
        lit = GetComponent<Light2D>();
        PlayerController.OnBulbOn += OnBulbOn;
        PlayerController.OnBulbOff += OnBulbOff;
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
        co = StartCoroutine(FadeIn());
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
