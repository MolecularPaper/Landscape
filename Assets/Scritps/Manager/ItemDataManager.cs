using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

namespace Manager
{
    //스크립트 개요 작성
    public class ItemDataManager
    {
        #region Variables
        private static ItemDataManager itemDataManager;

        public static ItemDataManager idm
        {
            get
            {
                if (itemDataManager == null) {
                    itemDataManager = new ItemDataManager {
                        itemDatabase = Resources.Load("Data/Item Database") as ItemDatabase
                    };
                }

                return itemDataManager;
            }
        }

        private ItemDatabase itemDatabase;
        #endregion

        #region Methods
        public ItemData GetItem(string itemCode)
        {
            foreach (var item in itemDatabase.itemDatas) {
                if(item.itemCode == itemCode) {
                    return item;
                }
            }

            return null;
        }
        #endregion

    }
}
