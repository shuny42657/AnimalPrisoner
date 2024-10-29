using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameLogic.GamePlayer;

namespace GameLogic.WorkSpace
{
    public interface IPutAndTake
    {
        public bool Put(ItemName itemName);
        public ItemName Take();

        public ItemName Item { get; }

        public UnityEvent<ItemName> OnPut { get; }
        public UnityEvent OnTake { get; }
    }

    public interface IConditionChecker
    {
        public bool MeetCondition();
    }

    public interface ISet
    {
        public void Set();
        public UnityEvent<ItemName> OnSet { get; }
    }

    public interface IWork
    {
        public void Work(IPlayerStatus playerStatus);
        //public UnityEvent<float> OnProgressMade { get; }
        //public UnityEvent<ItemName> OnWorkFinish { get; }
        public float WorkSpeed { get; set; }
    }

    public interface IAutomatable
    {
        public UnityEvent OnOperationFinish { get; }
        public UnityEvent<float> OnProgressMade { get; }
        public UnityEvent OnOperationInitiated { get; }
        public void InitiateOperation();
        public float OperationSpeed { get; set; }
    }
}
