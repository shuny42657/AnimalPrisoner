using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using UnityEngine.Events;

namespace GameLogic.GamePlayer
{
    public class PlayerOperatableHander : MonoBehaviour, IOperatableHandler,IOperatableCallback
    {
        BaseWorkSpace operatable;
        IInteractable interactable;

        ItemName item;

        public IOperatable Operatable { get { return operatable; } set { operatable = (BaseWorkSpace)value; } }

        public IInteractable Interactable { get { return interactable; } set { interactable = value; } }

        UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        UnityEvent<ItemName> onTake = new(); public UnityEvent<ItemName> OnTake { get { return onTake; } }

        public void InitiateWork()
        {
            if (operatable == null)
            {
                Debug.Log("no operatable");
                return;
            }
            else
            {
                Debug.Log("operator handler passed");
                operatable.InitiateOperation();
            }
        }

        public void PutOrTake()
        {
            if (operatable == null)
                return;
            else
            {
                Debug.Log("Put or Take");
                if (item == ItemName.None)
                {
                    Debug.Log("Take called");
                    item = operatable.Take();
                    if (item != ItemName.None)
                    {
                        Debug.Log("Get Item !!");
                        onTake.Invoke(item);
                    }
                }
                else
                {
                    Debug.Log("Put Called");
                    var isPut = operatable.Put(item);
                    if (isPut)
                    {
                        item = ItemName.None;
                        onPut.Invoke(item);
                    }
                }
            }
        
        }

        public void Work(IPlayerStatus playerStatus)
        {
            operatable.Work(playerStatus);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BaseWorkSpace baseWorkSpace))
            {
                if(operatable != null)
                    operatable.PlayerTrigger.OnPlayerExit.Invoke();
                operatable = baseWorkSpace;
                baseWorkSpace.PlayerTrigger.OnPlayerEnter.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out BaseWorkSpace baseWorkSpace))
            {
                if(operatable == baseWorkSpace)
                {
                    operatable = null;
                    baseWorkSpace.PlayerTrigger.OnPlayerExit.Invoke();
                }
            }
        }
    }
}
