using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    private Item item;
    public List<Item> items = new();
    public static SpawnObjects instance;

    private void Start()
    {
        instance = this;
    }

    public void Spawn()
    {
        for (int i = 0; i < items.Count; i++)
        {
            item = items[i];
            Chest.instance.PutInEmptySlot(item);
        }
        TakeItem.instance.ClearList(items);
    }
    public void AddList(Item Item)
    {
        items.Add(Item);
        Chest.instance.PutInEmptySlot(Item);
    }
}
