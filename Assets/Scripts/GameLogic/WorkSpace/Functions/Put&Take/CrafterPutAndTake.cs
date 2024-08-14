using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameLogic.Data;

namespace GameLogic.WorkSpace
{
    public class CrafterPutAndTake : MonoBehaviour,IPutAndTake,ISet
    {
        ItemName  item = ItemName.None;
        public ItemName Item { get { return item; } }

        ItemName itemToCraft;
        [SerializeField] ItemName firstItem;
        [SerializeField] ItemName secondItem;
        int firstItemCount = 0;
        int secondItemCount = 0;

        [SerializeField]UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        [SerializeField]UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }
        [SerializeField] UnityEvent<ItemName> onSet = new(); public UnityEvent<ItemName> OnSet { get { return onSet; } }

        //Todo : Reference something like "CraftItemDatabase" ??
        ICraftRecipe craftRecipe;

        public bool Put(ItemName itemName)
        {
            if(craftRecipe == null)
            {
                craftRecipe = CraftRecipeClassifier.GetCraftRecipe(firstItem, secondItem);
            }
            if(firstItem == itemName)
            {
                firstItemCount++;
                itemToCraft = craftRecipe.GetCraftItem(firstItemCount, secondItemCount);
                onPut.Invoke(itemToCraft);
                return true;
            }
            else if(secondItem == itemName)
            {
                secondItemCount++;
                itemToCraft = craftRecipe.GetCraftItem(firstItemCount, secondItemCount);
                onPut.Invoke(itemToCraft);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ItemName Take()
        {
            var temp = item;
            item = ItemName.None;
            Debug.Log($"Taken Item : {temp}");
            onTake.Invoke();
            return temp;
        }

        public void ResetSetQuantity()
        {
            firstItemCount = 0;
            secondItemCount = 0;
        }

        //Only this method is from ISet
        public void Set(ItemName itemName)
        {
            if (item == ItemName.None)
            {
                item = itemName;
                Debug.Log($"Set Item : {itemName}");
                onSet.Invoke(item);
            }
        }
    }
}
