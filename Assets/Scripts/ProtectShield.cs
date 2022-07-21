using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectShield : MonoBehaviour
{
    int maxBulb = 3;
    int minBulb = 0;
    int bulb = 3; // Àü±¸
    Vector3[] size = new Vector3[4];
    void Start()
    {
        size[3] = new Vector3(5, 5, 1);
        size[2] = new Vector3(4, 4, 1);
        size[1] = new Vector3(3, 3, 1);
        size[0] = new Vector3(0, 0, 1);
        transform.localScale = size[3];
    }

    void Update()
    {
    }

    public void GetAttacked()
    {
        bulb = Mathf.Max(minBulb, bulb - 1);
        transform.localScale = size[bulb];
    }

    public void GetBulb()
    {
        bulb = Mathf.Min(maxBulb, bulb + 1);
        transform.localScale = size[bulb];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetAttacked();
    }
}
