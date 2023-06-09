using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotTest : MonoBehaviour
{
    public Item item = null;
    public Image itemImage;
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    public void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    public void SetOutlineDistance(Vector2 distance)
    {
        outline.effectDistance = distance;
    }

    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.itemImage;

        SetColor(1);
    }

    private void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }

}

