using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    bool isOpened;
    public static Inventory instance;
    public Transform slotsParent;
    private InventorySlot[] inventorySlots = new InventorySlot[9];
    public List<Item> items = new();
    public GameObject panel;

    private void Start()
    {
        instance = this;

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i] = slotsParent.GetChild(i).GetComponent<InventorySlot>();
        }
    }

    public void PutInEmptySlot(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].slotItem == null)
            {
                items.Add(item);
                inventorySlots[i].PutInSlot(item);
                return;
            }
                
        }
    }
    private void Update()
    {
        if (isOpened)
        {
            gameObject.transform.localScale = Vector3.one;
            panel.transform.localScale = Vector3.one;
        }

        else
        {
            gameObject.transform.localScale = Vector3.zero;
            panel.transform.localScale = Vector3.zero;
        }


        ItemInfo.instance.ClearList(items);
    }
    public void OpenInventory()
    {
        isOpened = true;
    }

    public void CloseInventory()
    {
        isOpened = false;
    }
}
