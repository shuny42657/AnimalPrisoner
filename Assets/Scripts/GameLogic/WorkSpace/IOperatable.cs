using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using GameLogic.GamePlayer;

namespace GameLogic.WorkSpace
{
    public interface IOperatable
    {
        public bool Put(ItemName itemName);
        public ItemName Take();
        public void Work(IPlayerStatus playerStatus);
        public void InitiateOperation();
    }

    public interface IOperatableCallback
    {
        public UnityEvent<ItemName> OnPut { get; }
        public UnityEvent<ItemName> OnTake { get; }
    }
}
