using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLight : MonoBehaviour
{
    Light2D lit;
    float defLight = 0.1f;
    float speed = 0.0001f;
    Coroutine co;
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
        lit.intensity = 0f;
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

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.2f);
        while (lit.intensity < defLight)
        {
            lit.intensity += speed;
            yield return null;
        }
    }
}
