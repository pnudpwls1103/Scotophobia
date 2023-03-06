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
    
    private SlotTest[] slots;
    private SlotTest activeSlot = null;

    private float doubleClickInterval = 0.25f;
    private float doubleClickedTime = -1.0f;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<SlotTest>();
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

    private void OnMouseDoubleClick()
    {
        Debug.Log("더블 클릭");
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
        if (CheckMouseDoubleClick())
        {
            OnMouseDoubleClick();
        }
        else
        {
            GameObject clickedObject = _eventData.pointerCurrentRaycast.gameObject;
            SetActiveSlot(clickedObject);
        }
    }
}
