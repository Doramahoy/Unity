
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item slotItem;
    public GameObject ItemObj;
    Image icon;
    Button slotButton;
    float clicked = 0;
    float clicktime = 0;
    readonly float clickdelay = 0.5f;
    bool isClicked;

    private void Start()
    {
        icon = gameObject.transform.GetChild(0).GetComponent<Image>();
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
            if (Chest.isOpened == true)
            {
                ItemInfo.instance.Take(slotItem, ItemObj, this);
                isClicked = false;
            }
            else
            {
                ItemInfo.instance.Drop(slotItem, ItemObj, this);
                isClicked = false;
            }
        }
        else if (clicked == 1 && Time.time - clicktime > clickdelay) 
        { 
            clicked = 0;
            clicktime = 0;
            ItemInfo.instance.Open(slotItem, ItemObj, this);
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
