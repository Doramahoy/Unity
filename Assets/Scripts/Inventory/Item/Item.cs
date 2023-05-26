using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("������� ��������������")]
    public string Name = " ";
    public string Descripition = "�������� ��������";
    public Sprite icon = null;
    public GameObject itemObj;
    public int amount;
    public int count;
}
