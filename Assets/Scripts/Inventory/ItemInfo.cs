using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public static ItemInfo instance;

    private Text Title;
    private Text Descripiton;
    private Image Icon;
    private Item item;
    private InventorySlot CurrentSlot;
    public List<Item> Items = new();
    private GameObject ItemObj;

    private void Start()
    {
        instance = this;

        Title = transform.GetChild(0).GetComponent<Text>();
        Descripiton = transform.GetChild(1).GetComponent<Text>();
        Icon = transform.GetChild(2).GetComponent<Image>();
    }

    public void ChangeInfo(Item item)
    {
        Title.text = item.Name;
        Descripiton.text = item.Descripition;
        Icon.sprite = item.icon;
    }
    public void Drop(Item slotItem, GameObject itemObj, InventorySlot currentSlot)
    {
        ItemObj = itemObj;
        item = slotItem;
        CurrentSlot = currentSlot;
        Vector3 DropPos = new(Player.instance.transform.position.x + 2f, Player.instance.transform.position.y);
        Instantiate(ItemObj, DropPos, Quaternion.identity);
        Items.Remove(item);
        CurrentSlot.ClearSlot();
        Close();
    }

    public void Take(Item slotItem, GameObject itemObj, InventorySlot currentSlot)
    {
        ItemObj = itemObj;
        item = slotItem;
        CurrentSlot = currentSlot;
        SpawnObjects.instance.AddList(item);
        Items.Remove(item);
        CurrentSlot.ClearSlot();
        Close();
    }
    public void ClearList(List<Item> items)
    {
        Items = items;
    }

    public void Open(Item slotItem, GameObject itemObj,InventorySlot currentSlot)
    {
        gameObject.transform.localScale = Vector3.one;
        ChangeInfo(slotItem);
        ItemObj = itemObj;
        item = slotItem;
        CurrentSlot = currentSlot;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}
