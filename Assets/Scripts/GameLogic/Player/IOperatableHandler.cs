using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

namespace GameLogic.GamePlayer
{
    public interface IOperatableHandler
    {
        public IOperatable Operatable { get; set; }
        public IInteractable Interactable { get; set; }
        public void PutOrTake(IPutAndTake putAndTake);
        public void Work(IWork work, IPlayerStatus playerStatus);
        public void InitiateWork();
    }
}
