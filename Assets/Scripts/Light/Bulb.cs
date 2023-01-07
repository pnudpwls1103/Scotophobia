using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bulb : MonoBehaviour
{
    public Light2D lit;
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
        lit.enabled = true;
    }

    void OnBulbOff()
    {
        lit.enabled = false;
    }
}
