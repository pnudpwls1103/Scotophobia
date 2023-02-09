using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BulbTest : MonoBehaviour
{
    public Light2D lit;
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
        lit.enabled = true;
    }

    void OnBulbOff()
    {
        lit.enabled = false;
    }
}
