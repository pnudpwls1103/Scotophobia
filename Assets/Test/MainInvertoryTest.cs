using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MainInvertoryTest : MonoBehaviour, IPointerClickHandler
{
    
    [SerializeField]
    private GameObject go_MainSlotsParent;
    private SlotTest[] slots;
    public SlotTest activeSlot = null;

    void Start()
    {
        slots = go_MainSlotsParent.GetComponentsInChildren<SlotTest>();
        //ResetItemInfo();
    }

    public void SetMainSlotItem(Item _item)
    {
        slots[(int)_item.itemType].AddItem(_item);
    }

    private void SetActiveSlot(GameObject _clickedObject)
    {
        if(activeSlot != null)
        {
            activeSlot.SetOutlineDistance(new Vector2(0, 0));
        }
        activeSlot = _clickedObject.GetComponent<SlotTest>();
        activeSlot.SetOutlineDistance(new Vector2(10, 10));
    }

    private void OnMouseSlotClick(GameObject _clickedObject)
    {
        Item item = _clickedObject.GetComponent<SlotTest>().item;
        if(item == null) return;
        
        SetActiveSlot(_clickedObject);
    }

    public void OnPointerClick(PointerEventData _eventData)
    {   
        GameObject clickedObject = _eventData.pointerCurrentRaycast.gameObject;
        if(clickedObject.name.Contains("MainSlot"))
        {
            OnMouseSlotClick(clickedObject);
        }
    }
}
