using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UICTRL;

namespace Player
{
    //플레이어 인벤토리 컨트롤러
    public class PlayerInventroyCTRL : MonoBehaviour
    {
        #region Variables
        [SerializeField] private InventoryUICTRL inventoryUICTRL;

        public List<string> haveItems = new List<string>();
        #endregion

        #region Unity Event Methods
        private void Start()
        {
            haveItems = GameDataManager.gdm.LoadInventoryData().ToList();

            inventoryUICTRL = FindObjectOfType<InventoryUICTRL>();
            inventoryUICTRL.LoadUI(haveItems);
        }
        #endregion

        #region Methods
        public void GetItem(string itemCode)
        {
            haveItems.Add(itemCode);
            inventoryUICTRL.AddSlot(itemCode);
        }

        public void RemoveItem(string itemCode)
        {
            haveItems.Remove(itemCode);
            inventoryUICTRL.DestoyInventorySlot(itemCode);
        }

        public bool FindKey(string keyItemCode)
        {
            foreach (var code in haveItems) {
                if (code == keyItemCode) {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }

}