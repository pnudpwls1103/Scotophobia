using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    // 인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력 차단
    public static bool inventoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBackground;
    [SerializeField]
    private GameObject go_SlotsParent;
    
    private SlotTest[] slots;

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
}
