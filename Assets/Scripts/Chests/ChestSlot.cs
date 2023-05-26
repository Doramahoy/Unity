using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour
{
    public Item slotItem;
    public GameObject ItemObj;
    Image icon;
    Button slotButton;
    Text Count;
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;
    bool isClicked;
    private void Start()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
        Count = gameObject.transform.GetChild(1).GetComponent<Text>();
        slotButton = GetComponent<Button>();
        icon.enabled = false;
        slotButton.onClick.AddListener(SlotClicked);
        slotButton.onClick.AddListener(Click);
    }
    private void Update()
    {
        if (isClicked)
        {
            SlotClicked();
        }
    }
    public void PutInSlot(Item item)
    {
        icon.sprite = item.icon;
        slotItem = item;
        ItemObj = item.itemObj;
        icon.enabled = true;
    }
    public void Clicked()
    {
        if (isClicked == false)
        {
            clicktime = Time.time;
            isClicked = true;
        }

        if (clicked == 2 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            TakeItem.instance.Take(slotItem, this);
            isClicked = false;

        }
        else if (clicked == 1 && Time.time - clicktime > clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            TakeItem.instance.Open(slotItem, this);
            isClicked = false;
        }

    }
    public void Click()
    {
        clicked++;
    }
    public void SlotClicked()
    {
        if (slotItem != null)
            Clicked();
    }

    public void ClearSlot()
    {
        slotItem = null;
        ItemObj = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
