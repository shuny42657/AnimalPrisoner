using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using UnityEngine.Events;

namespace GameLogic.GamePlayer
{
    public class PlayerOperatableHander : MonoBehaviour, IOperatableHandler,IOperatableCallback
    {
        BaseWorkSpace _workSpace;
        IInteractable interactable;

        ItemName item;

        public IOperatable Operatable { get { return _workSpace; } set { _workSpace = (BaseWorkSpace)value; } }

        public IInteractable Interactable { get { return interactable; } set { interactable = value; } }

        UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        UnityEvent<ItemName> onTake = new(); public UnityEvent<ItemName> OnTake { get { return onTake; } }

        public void InitiateWork(IAutomatable automatable)
        {
                Debug.Log("operator handler passed");
                automatable.InitiateOperation();
        }

        public void PutOrTake(IPutAndTake putAndTake)
        {
            /*if (_workSpace == null)
                return;
            else
            {
                Debug.Log("Put or Take");
                if (item == ItemName.None)
                {
                    Debug.Log("Take called");
                    item = _workSpace.Take();
                    if (item != ItemName.None)
                    {
                        Debug.Log("Get Item !!");
                        onTake.Invoke(item);
                    }
                }
                else
                {
                    Debug.Log("Put Called");
                    var isPut = _workSpace.Put(item);
                    if (isPut)
                    {
                        item = ItemName.None;
                        onPut.Invoke(item);
                    }
                }
            }*/

            if(item == ItemName.None)
            {
                Debug.Log("Take called");
                item = putAndTake.Take();
                if(item != ItemName.None)
                {
                    Debug.Log("GET ITEM !!");
                    onTake.Invoke(item);
                }
            }
            else
            {
                Debug.Log("PUT CALLED");
                var isPut = putAndTake.Put(item);
                if (isPut)
                {
                    item = ItemName.None;
                    onPut.Invoke(item);
                }
            }
        }

        public void Work(IWork work,IPlayerStatus playerStatus)
        {
            work.Work(playerStatus);
            //_workSpace.Work(playerStatus);
        }

        private void OnTriggerEnter(Collider other)
        {
            /*if (other.TryGetComponent(out BaseWorkSpace baseWorkSpace))
            {
                if(_workSpace != null)
                    _workSpace.PlayerTrigger.OnPlayerExit.Invoke();
                _workSpace = baseWorkSpace;
                baseWorkSpace.PlayerTrigger.OnPlayerEnter.Invoke();
            }*/
            if(other.TryGetComponent(out IPlayerTrigger playerTrigger))
            {
                playerTrigger.OnPlayerEnter();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            /*if(other.TryGetComponent(out BaseWorkSpace baseWorkSpace))
            {
                if(_workSpace == baseWorkSpace)
                {
                    _workSpace = null;
                    baseWorkSpace.PlayerTrigger.OnPlayerExit.Invoke();
                }
            }*/

            if(other.TryGetComponent(out IPlayerTrigger playerTrigger))
            {
                playerTrigger.OnPlayerExit();
            }
        }
    }
}
