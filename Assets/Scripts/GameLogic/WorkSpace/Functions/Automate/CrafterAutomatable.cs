using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class CrafterAutomatable : BaseAutomatable<ItemName>
    {
        //bool working;
        //ItemName itemToCraft;

        public void SetItemToCraft(ItemName itemName)
        {
            Debug.Log($"Set Item : {itemName}");
            item = itemName;
        }

        public override void InitateOperation()
        {
            if (!IsActive && item != ItemName.None)
            {
                OnOperationInitiated.Invoke();
                IsActive = true;
            }
            else
            {
                Debug.Log("Cannot Start Operation");
            }
        }
    }
}
