using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOpenChest : MonoBehaviour
{
    bool isOpened;
    [SerializeField] GameObject Chest;
    private void Start()
    {

    }
    private void Update()
    {
        if (isOpened)
            Chest.transform.localScale = Vector3.one;
        else
            Chest.transform.localScale = Vector3.zero;
    }
    public void Open()
    {
        isOpened = true;
    }
    public void Close()
    {
        isOpened = false;
    }
}
