using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Util;
using GameLogic.GamePlayer;
using UI;

namespace GameLogic.WorkSpace
{
    public class BaseWorkSpace : MonoBehaviour, IOperatable
    {
        protected JobName jobName; public JobName JobName { get { return jobName; } }
        protected IPutAndTake _putAndTake;
        protected IAutomatable _automatable;
        protected IWork _work;
        protected ISet _set;
        protected IPlayerTriggerable _playerTrigger; public IPlayerTriggerable PlayerTrigger { get { return _playerTrigger; } }
        protected IUpGradable upGradable; public IUpGradable UpGradable { get { return upGradable; } }
        protected IGrabbableVisualizer _grabbableVisualizer;
        protected IHilightVisualizer _hilightVisualizer;
        [SerializeField] protected WorkSpaceProgressView _progressView;

        public virtual void InitializeWorkSpace()
        {
            TryGetComponent(out _putAndTake);
            TryGetComponent(out _automatable);
            TryGetComponent(out _work);
            TryGetComponent(out _playerTrigger);
            TryGetComponent(out upGradable);
            TryGetComponent(out _set);
            TryGetComponent(out _grabbableVisualizer);
            _hilightVisualizer = GetComponent<IHilightVisualizer>();

            _playerTrigger.OnPlayerEnter.AddListener(() => _hilightVisualizer.Hilight(true));
            _playerTrigger.OnPlayerExit.AddListener(() => _hilightVisualizer.Hilight(false));
        }
        public void InitiateOperation()
        {
            if (_automatable != null)
            {
                Debug.Log("workspace automatable called");
                _automatable.InitateOperation();
            }
            else
            {
                Debug.Log("no automatable");
                return;
            }
        }

        public bool Put(ItemName itemName)
        {
            if (_putAndTake != null)
            {
                Debug.Log("Item Put");
                return _putAndTake.Put(itemName);
            }
            else
            {
                Debug.Log("Fail");
                return false;
            }
        }

        public ItemName Take()
        {
            if (_putAndTake != null)
            {
                return _putAndTake.Take();
            }
            else
            {
                return ItemName.None;
            }
        }

        public void Work(IPlayerStatus playerStatus)
        {
            if (_work != null)
            {
                _work.Work(playerStatus);
            }
        }

        public void UpGrade()
        {
            upGradable.UpGrade();
        }
    }
}


