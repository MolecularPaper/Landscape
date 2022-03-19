using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Manager;
using Data;

namespace UICTRL
{
    //인벤토리 UI 컨트롤러
    public class InventoryUICTRL : MonoBehaviour
    {
        #region Variables
        [SerializeField] private ItemInfo itemInfo;

        [Header("ItemList")]
        [SerializeField] private Transform itemList;
        [SerializeField] private GameObject inventorySlot;
                         
        private List<InventorySlot> enabledInventorySlots = new List<InventorySlot>();
        private Queue<InventorySlot> disableInventorySlots = new Queue<InventorySlot>();

        #endregion

        #region Properties
        //프로퍼티 작성
        #endregion

        #region Methods
        public void LoadUI(List<string> itemCodes)
        {
            foreach (var code in itemCodes) {
                AddSlot(code);
            }
        }

        public void AddSlot(string itemCode)
        {
            InventorySlot slot;
            if(disableInventorySlots.Count > 0) {
                slot = disableInventorySlots.Peek();
            }
            else {
                slot = Instantiate(inventorySlot, Vector3.zero, Quaternion.identity, itemList).GetComponent<InventorySlot>();
            }

            slot.SetSlot(itemCode);
            enabledInventorySlots.Add(slot);
        }

        public void DestoyInventorySlot(string itemCode)
        {
            foreach (var slot in enabledInventorySlots) {
                if(slot.itemCode == itemCode) {
                    enabledInventorySlots.Remove(slot);
                    disableInventorySlots.Enqueue(slot);
                    slot.gameObject.SetActive(false);
                    break;
                }
            }
        }

        public void ViewItemInfo(string itemCode)
        {
            ItemData item = ItemDataManager.idm.GetItem(itemCode);
            itemInfo.SetUI(item);
        }
        #endregion
    }
}
