using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

public class Floor : MonoBehaviour, IOperatable
{
    IGrabbable onFloor;
    public bool Put(IGrabbable grabbable)
    {
        if (onFloor == null)
        {
            onFloor = grabbable;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InitiateOperation()
    {
        return;
    }

    public IGrabbable Take()
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
            handler.Operatable = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IOperatableHandler handler))
        {
            if(this == (Object)handler.Operatable)
                handler.Operatable = null;
        }
    }
}
