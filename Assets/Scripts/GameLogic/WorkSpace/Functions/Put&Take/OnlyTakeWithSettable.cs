using System.Collections;
using System.Collections.Generic;
using GameLogic.GamePlayer;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class OnlyTakeWithSettable : MonoBehaviour, IPutAndTake,ISet
    {
        ItemName _item;
        ItemName _itemToSet;
        public ItemName Item { get { return _item; } }

        UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        UnityEvent<ItemName> onSet = new(); public UnityEvent<ItemName> OnSet { get { return onSet; } }

        public OnlyTakeWithSettable(ItemName itemToSet)
        {
            _itemToSet = itemToSet;
        }
        
        public bool Put(ItemName itemName)
        {
            return false;
        }

        public ItemName Take()
        {
            var temp = _item;
            _item = ItemName.None;
            onTake.Invoke();
            Debug.Log("Taken");
            return temp;
        }

        public void Set()
        {
            if(_item == ItemName.None)
            {
                _item = _itemToSet;
                onSet.Invoke(_item);
            }
        }
    }
}
