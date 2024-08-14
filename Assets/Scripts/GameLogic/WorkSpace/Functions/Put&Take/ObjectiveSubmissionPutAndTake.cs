using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameLogic.GameSystem;

namespace GameLogic.WorkSpace
{
    public class ObjectiveSubmissionPutAndTake : MonoBehaviour,IPutAndTake
    {
        ItemName item;
        public ItemName Item { get { return item; } }

        [SerializeField] ObjectiveManager objectiveManager;

        UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        public bool Put(ItemName itemName)
        {
            onPut.Invoke(itemName);
            var achieved = objectiveManager.ObjectiveAchieved(itemName);
            return true;
        }

        public ItemName Take()
        {
            return ItemName.None;
        }
    }
}
