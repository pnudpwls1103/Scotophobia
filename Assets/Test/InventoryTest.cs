using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryTest : MonoBehaviour, IPointerClickHandler
{
    // 인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력 차단
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBackground;
    [SerializeField]
    private GameObject go_SlotsParent;
    [SerializeField]
    private GameObject go_ItemInfo;
    [SerializeField]
    private MainInvertoryTest mainInvertory;

    
    private SlotTest[] slots;
    private SlotTest activeSlot = null;

    private float doubleClickInterval = 0.25f;
    private float doubleClickedTime = -1.0f;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<SlotTest>();
        ResetItemInfo();
    }

    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }
    }

    private void OpenInventory()
    {
        go_InventoryBackground.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBackground.SetActive(false);
    }

    public void AcquireItem(Item _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item);
                return;
            }   
        }
    }

    private void OnMouseSlotClick(GameObject _clickedObject)
    {
        Item item = _clickedObject.GetComponent<SlotTest>().item;
        if(item == null) return;
        
        SetActiveSlot(_clickedObject);
        ResetItemInfo();
        SetItemInfo(_clickedObject);
    }

    private void OnMouseSlotDoubleClick(GameObject _clickedObject)
    {
        Item clickedItem = _clickedObject.GetComponent<SlotTest>().item;
        mainInvertory.SetMainSlotItem(clickedItem);
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

    private void SetItemInfo(GameObject _clickedObject)
    {
        SlotTest currentSlot = _clickedObject.GetComponent<SlotTest>();
        UnityEngine.UI.Image itemImage = go_ItemInfo.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        TMPro.TextMeshProUGUI itemNameText = go_ItemInfo.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI itemDescriptionText = go_ItemInfo.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();

        Item item = currentSlot.item;
        itemImage.sprite = item.itemImage;
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.description;

        Color imageColor = itemImage.color;
        imageColor.a = 1f;
        itemImage.color = imageColor;
    }

    private void ResetItemInfo()
    {
        UnityEngine.UI.Image itemImage = go_ItemInfo.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        TMPro.TextMeshProUGUI itemNameText = go_ItemInfo.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI itemDescriptionText = go_ItemInfo.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();

        Color imageColor = itemImage.color;
        imageColor.a = 0f;
        itemImage.color = imageColor;

        itemNameText.text = "";
        itemDescriptionText.text = "";
    }

    private bool CheckMouseDoubleClick()
    {
        bool isDoubleClicked = false;
        if ((Time.time - doubleClickedTime) < doubleClickInterval)
        {
            isDoubleClicked = true;
            doubleClickedTime = -1.0f;
        }
        else
        {
            isDoubleClicked = false;
            doubleClickedTime = Time.time;
        }

        return isDoubleClicked;
    }

    public void OnPointerClick(PointerEventData _eventData)
    {   
        GameObject clickedObject = _eventData.pointerCurrentRaycast.gameObject;
        if(clickedObject.name.Contains("Slot"))
        {
            if (CheckMouseDoubleClick())
            {
                OnMouseSlotDoubleClick(clickedObject);
            }
            else
            {
                OnMouseSlotClick(clickedObject);
            }
        }
    }
}
