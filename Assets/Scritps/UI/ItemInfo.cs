using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Data;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemInfoText;
    [SerializeField] private Image itemImage;

    private void OnDisable()
    {
        ResetUI();
        gameObject.SetActive(false);
    }

    public void ResetUI()
    {
        itemNameText.text = "";
        itemTypeText.text = "";
        itemInfoText.text = "";
        itemImage.sprite = null;
    }

    public void SetUI(ItemData item)
    {
        itemNameText.text = item.itemName;
        itemTypeText.text = item.itemType.ToString();
        itemInfoText.text = item.itemInfo;
        itemImage.sprite = item.itemImage;

        gameObject.SetActive(true);
    }
}
