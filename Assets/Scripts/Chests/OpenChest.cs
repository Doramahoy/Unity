using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    private bool isOpened;
    [SerializeField]
    Canvas openButChest;

    void Update()
    {
        if (isOpened)
            openButChest.enabled = true;
        else
            openButChest.enabled = false;
            

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOpened = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOpened = false;
    }
}
