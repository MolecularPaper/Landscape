using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class ItemData
    {
        [SerializeField]
        public ItemType itemType = Data.ItemType.Etc;
        public Sprite itemIcon = null;
        public Sprite itemImage = null;
        public string itemCode;
        public string itemName = "";
        [TextArea]
        public string itemInfo = "";
        public bool disposable = true;
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "Item Database", menuName = "Item Database")]
    public class ItemDatabase : ScriptableObject
    {
        public List<ItemData> itemDatas = new List<ItemData>();
    }
}
