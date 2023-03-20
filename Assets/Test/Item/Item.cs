using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public DefineTest.ItemType itemType;
    public Sprite itemImage;
    public string description;

    // void Start()
    // {
    //     GlobalLight.OnFadeIn += OnFadeIn;
    // }

    // void OnFadeIn()
    // {
    //     //Debug.Log($"{transform.name} ��¦");
    // }

    // private void OnDisable()
    // {
    //     GlobalLight.OnFadeIn -= OnFadeIn;
    // }
}
