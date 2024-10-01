using System.Collections;
using System.Collections.Generic;
using GameLogic.GamePlayer;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class OnlyTakeWithSettable : MonoBehaviour, IPutAndTake,ISet
    {
        ItemName item;
        public ItemName Item { get { return item; } }

        [SerializeField] UnityEvent<ItemName> onPut; public UnityEvent<ItemName> OnPut { get { return onPut; } }

        [SerializeField] UnityEvent onTake; public UnityEvent OnTake { get { return onTake; } }

        UnityEvent<ItemName> onSet = new(); public UnityEvent<ItemName> OnSet { get { return onSet; } }

        public bool Put(ItemName itemName)
        {
            return false;
        }

        public ItemName Take()
        {
            var temp = item;
            item = ItemName.None;
            onTake.Invoke();
            Debug.Log("Taken");
            return temp;
        }

        public void Set(ItemName itemName)
        {
            if(item == ItemName.None)
            {
                item = itemName;
                onPut.Invoke(item);
            }
        }
    }
}
