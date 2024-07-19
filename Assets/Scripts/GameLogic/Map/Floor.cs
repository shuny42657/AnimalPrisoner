using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using UnityEngine.Events;

public class Floor : MonoBehaviour, IOperatable,IInteractable
{
    IResource onFloor;

    public UnityEvent onEnter = new();
    public UnityEvent onExit = new();
    public UnityEvent OnEnter { get { return onEnter; } }
    public UnityEvent OnExit { get { return onExit; } }

    public bool Put(IGrabbable grabbable)
    {
        return false;
    }

    public void InitiateOperation()
    {
        return;
    }

    public IResource Take()
    {
        var grabbable = onFloor;
        onFloor = null;
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

    public bool Put(IResource recource)
    {
        if (onFloor == null)
        {
            onFloor = recource;
            return true;
        }
        else
        {
            return false;
        }
    }
}
