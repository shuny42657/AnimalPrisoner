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

    public interface ISet
    {
        public void Set(ItemName itemName);
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
        public void InitateOperation();
        public float OperationSpeed { get; set; }

    }
}
