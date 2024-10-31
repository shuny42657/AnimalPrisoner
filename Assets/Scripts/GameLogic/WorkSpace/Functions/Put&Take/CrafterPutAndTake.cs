using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameLogic.Data;

namespace GameLogic.WorkSpace
{
    public class CrafterPutAndTake :IPutAndTake,ISet,IConditionChecker
    {
        ItemName  item = ItemName.None;
        public ItemName Item { get { return item; } }

        ItemName itemToCraft;
        [SerializeField] ItemName _firstItem;
        [SerializeField] ItemName _secondItem;
        int _firstItemCount = 0;
        int _secondItemCount = 0;

        [SerializeField]UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        [SerializeField]UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }
        [SerializeField] UnityEvent<ItemName> onSet = new(); public UnityEvent<ItemName> OnSet { get { return onSet; } }

        //Todo : Reference something like "CraftItemDatabase" ??
        ICraftRecipe _craftRecipe;

        public CrafterPutAndTake(ItemName firstItem,ItemName secondItem)
        {
            _firstItem = firstItem;
            _secondItem = secondItem;
            _craftRecipe = CraftRecipeClassifier.GetCraftRecipe(_firstItem, _secondItem);
        }

        public bool MeetCondition()
        {
            return _firstItemCount > 0 && _secondItemCount > 0 && item == ItemName.None;
        }

        public bool Put(ItemName itemName)
        {
            if(_craftRecipe == null)
            {
                _craftRecipe = CraftRecipeClassifier.GetCraftRecipe(_firstItem, _secondItem);
            }
            if(_firstItem == itemName)
            {
                _firstItemCount++;
                itemToCraft = _craftRecipe.GetCraftItem(_firstItemCount, _secondItemCount);
                onPut.Invoke(itemToCraft);
                return true;
            }
            else if(_secondItem == itemName)
            {
                _secondItemCount++;
                itemToCraft = _craftRecipe.GetCraftItem(_firstItemCount, _secondItemCount);
                onPut.Invoke(itemToCraft);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Set()
        {
            item = itemToCraft;
            itemToCraft = ItemName.None;
            onSet.Invoke(item);
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
            _firstItemCount = 0;
            _secondItemCount = 0;
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
