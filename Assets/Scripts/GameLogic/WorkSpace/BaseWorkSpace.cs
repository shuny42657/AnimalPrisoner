using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Util;
using GameLogic.GamePlayer;

namespace GameLogic.WorkSpace
{
    public class BaseWorkSpace : MonoBehaviour,IOperatable
    {
        [SerializeField] SerializeInterface<IPutAndTake> putAndTake;
        [SerializeField] SerializeInterface<IAutomatable> automatable;
        [SerializeField] SerializeInterface<IWork> work;
        [SerializeField] SerializeInterface<IPlayerTriggerable> playerTrigger; public IPlayerTriggerable PlayerTrigger { get { return playerTrigger.Value; } }

        public void InitiateOperation()
        {
            if(automatable.Value != null)
            {
                Debug.Log("workspace automatable called");
                automatable.Value.InitateOperation();
            }
            else
            {
                Debug.Log("no automatable");
                return;
            }
        }

        public bool Put(ItemName itemName)
        {
            if(putAndTake.Value != null)
            {
                Debug.Log("Item Put");
                return putAndTake.Value.Put(itemName);
            }
            else
            {
                Debug.Log("Fail");
                return false;
            }
        }

        public ItemName Take()
        {
            if(putAndTake.Value != null)
            {
                return putAndTake.Value.Take();
            }
            else
            {
                return ItemName.None;
            }
        }

        public void Work(IPlayerStatus playerStatus)
        {
            if(work.Value != null)
            {
                work.Value.Work(playerStatus);
            }
        }
    }
}


