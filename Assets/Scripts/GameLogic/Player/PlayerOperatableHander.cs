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
        }

        IPlayerTrigger _playerTrigger;
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IPlayerTrigger playerTrigger))
            {
                if(_playerTrigger != null)
                    _playerTrigger.OnPlayerExit();
                playerTrigger.OnPlayerEnter();
                _playerTrigger = playerTrigger;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out IPlayerTrigger playerTrigger))
            {
                playerTrigger.OnPlayerExit();
            }
        }
    }
}
