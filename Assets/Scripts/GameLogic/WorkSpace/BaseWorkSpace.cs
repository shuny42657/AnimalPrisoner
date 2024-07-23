using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Util;

namespace GameLogic.WorkSpace
{
    public class BaseWorkSpace : MonoBehaviour,IOperatable
    {
        [SerializeField] SerializeInterface<IPutAndTake> putAndTake;
        [SerializeField] SerializeInterface<IWork> work;
        [SerializeField] SerializeInterface<IAutomatable> automatable;
        [SerializeField] SerializeInterface<IPlayerTriggerable> playerTrigger; public IPlayerTriggerable PlayerTrigger { get { return playerTrigger.Value; } }

        public void InitiateOperation()
        {
            if(automatable.Value != null)
                automatable.Value.InitateOperation();
            else
            {
                return;
            }
        }

        public bool Put(IGrabbable grabbable)
        {
            throw new System.NotImplementedException();
        }

        public bool Put(IResource resource)
        {
            if(putAndTake.Value != null)
            {
                Debug.Log("Item Put");
                return putAndTake.Value.Put(resource);
            }
            else
            {
                Debug.Log("Fail");
                return false;
            }
        }

        public IResource Take()
        {
            if(putAndTake.Value != null)
            {
                return putAndTake.Value.Take();
            }
            else
            {
                return null;
            }
        }

        public void Work()
        {
            work.Value.Work();
        }
    }
}


