using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public static bool isOpened;
    public static Chest instance;
    public Transform slotsParent;
    private readonly ChestSlot[] chestSlots = new ChestSlot[15];

    private void Start()
    {
        instance = this;

        for (int i = 0; i < chestSlots.Length; i++)
        {
            chestSlots[i] = slotsParent.GetChild(i).GetComponent<ChestSlot>();
        }
    }
    public void ClearSlots()
    {
        for (int i = 0; i < chestSlots.Length; i++)
        {
            if (chestSlots[i].slotItem != null)
            {
                chestSlots[i].ClearSlot();
            }
        }
    }
    public void PutInEmptySlot(Item item)
    {
        for (int i = 0; i < chestSlots.Length; i++)
        {
            if (chestSlots[i].slotItem == null)
            {
                chestSlots[i].PutInSlot(item);
                return;
            }

        }
    }
    private void Update()
    {
        if (isOpened)
            gameObject.transform.localScale = Vector3.one;
        else
            gameObject.transform.localScale = Vector3.zero;

    }
    public void OpenChest()
    {
        isOpened = true;
    }

    public void CloseChest()
    {
        isOpened = false;
    }
}
