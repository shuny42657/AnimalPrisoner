using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class MakerPutAndTake : MonoBehaviour,IPutAndTake
    {
        ItemName item = ItemName.None;
        public ItemName Item { get { return item; } }

        UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        public bool Put(ItemName item)
        {
            if(this.item == ItemName.None)
            {
                //Debug.Log("Item Put");
                this.item = item;
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
            var temp = item;
            item = ItemName.None;
            onTake.Invoke();
            return temp;
        }
    }
}


