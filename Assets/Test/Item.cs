using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Housework,
        Abuse,
        Picture,
        ETC
    }

    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;


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
