using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public abstract class BaseAutomatable<T>: MonoBehaviour, IAutomatable, ISwitchable
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
}

