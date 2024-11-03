using System.Collections;
using System.Collections.Generic;
using GameLogic.GamePlayer;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public abstract class BaseWork<T> : MonoBehaviour, IWork
    {
        protected float progress;
        [SerializeField] protected float maxProgress;
        public UnityEvent OnWorkStart;
        public UnityEvent<T> OnWorkFinish;
        public UnityEvent<float> OnProgressMade;

        bool workStart = false;

        protected float workSpeed = 1f;
        public float WorkSpeed { get { return workSpeed; } set { workSpeed = value; } }

        [SerializeField] protected T item;

        public virtual void Work(IPlayerStatus playerStatus)
        {
            if(playerStatus.Energy > 0)
            {
                if (!workStart)
                {
                    workStart = true;
                    OnWorkStart.Invoke();
                }
                progress += Time.deltaTime * workSpeed;
                playerStatus.Energy -= Time.deltaTime * workSpeed;
                OnProgressMade.Invoke(progress / maxProgress);

                if(progress > maxProgress)
                {
                    progress = 0;
                    OnWorkFinish.Invoke(item);
                    workStart = false; ;
                }
            }
            else
            {
                Debug.Log("no work");
            }
        }
    }

    public class SimpleWork : IWork
    {
        protected float progress;
        protected float _maxProgress;
        public UnityEvent OnWorkStart = new(); 
        public UnityEvent OnWorkFinish = new();
        public UnityEvent<float> OnProgressMade = new();
        bool workStart = false;

        protected float _workSpeed = 1f;
        public float WorkSpeed { get { return _workSpeed; } set { _workSpeed = value; }}

        public SimpleWork(
            float maxProgress
            )
        {
            _maxProgress = maxProgress;
        }

        public virtual void Work(IPlayerStatus playerStatus)
        {
            if (playerStatus.Energy > 0)
            {
                if (!workStart)
                {
                    workStart = true;
                    OnWorkStart.Invoke();
                }
                progress += Time.deltaTime * _workSpeed;
                playerStatus.Energy -= Time.deltaTime * _workSpeed;
                OnProgressMade.Invoke(progress / _maxProgress);

                if (progress > _maxProgress)
                {
                    progress = 0;
                    OnWorkFinish.Invoke();
                    workStart = false; ;
                }
            }
            else
            {
                Debug.Log("no work");
            }
        }
    }
}

