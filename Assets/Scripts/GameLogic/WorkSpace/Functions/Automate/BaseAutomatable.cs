using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public abstract class BaseAutomatable<T>: MonoBehaviour, ISwitchable
    {
        public bool IsActive { get; set; }

        public abstract void InitateOperation();

        protected T item;
        public UnityEvent<T> onOperationFinish = new();
        public UnityEvent<float> OnProgressMade = new();
        public UnityEvent OnOperationInitiated = new();

        float progress;
        [SerializeField] protected float maxProgress;
        float operationSpeed = 1f;
        public float OperationSpeed { get { return operationSpeed; } set { operationSpeed = value; } }

        // Update is called once per frame
        protected void Update()
        {
            if (IsActive)
            {
                progress += Time.deltaTime * operationSpeed;
                OnProgressMade.Invoke(progress / maxProgress);
                if(progress > maxProgress)
                {
                    progress = 0;
                    IsActive = false;
                    onOperationFinish.Invoke(item);
                }
            }
        }
    }

    public class SimpleAutomatable : IAutomatable, ISwitchable, ITick
    {
        public bool IsActive { get; set; }
        protected UnityEvent onOperationFinish = new(); public UnityEvent OnOperationFinish { get { return onOperationFinish; } }
        protected UnityEvent<float> onProgressMade = new(); public UnityEvent<float> OnProgressMade { get { return onProgressMade; } }
        protected UnityEvent onOperationInitiated = new(); public UnityEvent OnOperationInitiated { get { return onOperationInitiated; } }

        protected float _maxProgress;
        protected float _progress;
        protected float operationSpeed = 1f;
        public float OperationSpeed { get { return operationSpeed; } set { operationSpeed = value; }}

        public SimpleAutomatable(float maxProgress)
        {
            IsActive = false;
            _maxProgress = maxProgress;
        }

        public void Tick()
        {
            if (IsActive)
            {
                _progress += Time.deltaTime * operationSpeed;
                onProgressMade.Invoke(_progress / _maxProgress);
                if(_progress > _maxProgress)
                {
                    _progress = 0f;
                    IsActive = false;
                    onOperationFinish.Invoke();
                }
            }
        }

        public virtual void InitiateOperation()
        {
            IsActive = true;
        }
    }
}

