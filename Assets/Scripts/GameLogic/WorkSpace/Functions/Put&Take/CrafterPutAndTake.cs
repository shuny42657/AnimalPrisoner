using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class CrafterPutAndTake : MonoBehaviour,IPutAndTake,ISet
    {
        public ItemName Item => throw new System.NotImplementedException();

        public UnityEvent<ItemName> OnPut => throw new System.NotImplementedException();

        public UnityEvent OnTake => throw new System.NotImplementedException();

        //Todo : Reference something like "CraftItemDatabase" ?? 

        public bool Put(ItemName itemName)
        {
            //Only accecpt valid items (2 kinds for each crafter).
            throw new System.NotImplementedException();
        }

        public ItemName Take()
        {
            //Give the crafted item to player only when there is one.
            //You can just copy the implementation from OnlyTakeWithSetter.cs
            throw new System.NotImplementedException();
        }

        //Only this method is from ISet
        public void Set(ItemName itemName)
        {
            //Set the itemName of an item that is crafted.
            //Can just copy the implementation from OnlyTakeWithSetter.cs 
            throw new System.NotImplementedException();
        }
    }
}
