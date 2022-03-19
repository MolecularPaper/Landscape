using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;
using UICTRL;
using TMPro;
using Data;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private Image itemIcon;

    public string itemCode { get; private set; }

    public void SetSlot(string itemCode)
    {
        this.itemCode = itemCode;

        ItemData itemData = ItemDataManager.idm.GetItem(itemCode);
        itemNameText.text = itemData.itemName;
        itemIcon.sprite = itemData.itemIcon;

        gameObject.SetActive(true);
    }

    public void ViewItemInfo()
    {
        FindObjectOfType<InventoryUICTRL>().ViewItemInfo(itemCode);
    }
}
