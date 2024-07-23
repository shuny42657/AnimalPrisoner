using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using UnityEngine.Events;
using Util;

public class Floor : MonoBehaviour, IOperatable,IInteractable,IOperatableCallback
{
    IResource onFloor;

    public UnityEvent onEnter = new();
    public UnityEvent onExit = new();
    public UnityEvent<IResource> onPut = new(); public UnityEvent<IResource> OnPut { get { return onPut; } }
    public UnityEvent<IResource> onTake = new(); public UnityEvent<IResource> OnTake { get { return onTake; } }

    public UnityEvent OnEnter { get { return onEnter; } }
    public UnityEvent OnExit { get { return onExit; } }

    
    public void InitiateOperation()
    {
        return;
    }

    public bool Put(IResource recource)
    {
        if (onFloor == null)
        {
            onFloor = recource;
            onPut.Invoke(onFloor);
            return true;
        }
        else
        {
            return false;
        }
    }
    public IResource Take()
    {
        var grabbable = onFloor;
        onFloor = null;
        onTake.Invoke(null);
        return grabbable;
    }

    public void Work()
    {
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IOperatableHandler handler))
        {
            if(handler.Interactable != null)
                handler.Interactable.OnExit.Invoke();
            handler.Operatable = this;
            handler.Interactable = this;
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IOperatableHandler handler))
        {
            if(this == (Object)handler.Operatable)
            {
                handler.Operatable = null;
                handler.Interactable = null;
            }
            onExit.Invoke();
        }
    }

    public bool Put(IGrabbable grabbable)
    {
        return false;
    }

}
