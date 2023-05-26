using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Базовые характеристики")]
    public string Name = " ";
    public string Descripition = "Описание предмета";
    public Sprite icon = null;
    public GameObject itemObj;
    public int amount;
    public int count;
}
