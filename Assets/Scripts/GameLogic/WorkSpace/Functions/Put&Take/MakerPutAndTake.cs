using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    //Put to put an item, Take to take away the item.
    public class BasicPutAndTake : IPutAndTake
    {
        ItemName _item = ItemName.None;

        UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        public BasicPutAndTake() { }

        public bool Put(ItemName item)
        {
            if(this._item == ItemName.None)
            {
                Debug.Log("Item Put");
                this._item = item;
                onPut.Invoke(item);
                return true;
            }
            else
            {
                Debug.Log("Fail");
                return false;
            }
        }

        public ItemName Take()
        {
            var temp = _item;
            _item = ItemName.None;
            onTake.Invoke();
            return temp;
        }
    }
}


