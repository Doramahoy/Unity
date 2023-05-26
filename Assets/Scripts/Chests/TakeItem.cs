using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    public static TakeItem instance;

    private Text Title;
    private Text Descripiton;
    private Image Icon;
    private ChestSlot ChestSlot;
    private Item item;
    public List<Item> Items = new();
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
    public void Take(Item slotItem, ChestSlot chestSlot)
    {
        item = slotItem;
        ChestSlot = chestSlot;
        Inventory.instance.PutInEmptySlot(item);
        Items.Remove(item);
        ChestSlot.ClearSlot();
        Close();
    }
    public void ClearList(List<Item> items)
    {
        Items = items;
    }

    internal void Open(Item slotItem, ChestSlot chestSlot)
    {
        gameObject.transform.localScale = Vector3.one;
        ChangeInfo(slotItem);
        item = slotItem;
        ChestSlot = chestSlot;
    }

    public void Close()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
}
