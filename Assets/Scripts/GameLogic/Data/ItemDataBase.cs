using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Data
{
    public class ItemDataBase : MonoBehaviour,IDataBase<ItemData,ItemName>
    {
        [SerializeField] List<ItemData> itemData;
        Dictionary<ItemName, ItemData> itemDict = new();

        private void Awake()
        {
            foreach(var i in itemData)
            {
                itemDict.Add(i.ItemName, i);
            }
        }
        public IEnumerable<ItemData> GetAllData()
        {
            return itemData;
        }

        public ItemData GetData(ItemName name)
        {
            return itemDict[name];
        }

        public ItemData GetDataByIndex(int index)
        {
            return itemData[index];
        }

    }
}

