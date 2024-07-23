using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using UnityEngine.Events;

public class PlayerOperatableHander : MonoBehaviour, IOperatableHandler,IOperatableCallback
{
    BaseWorkSpace operatable;
    IInteractable interactable;

    IResource resource;

    public IOperatable Operatable { get { return operatable; } set { operatable = (BaseWorkSpace)value; } }

    public IInteractable Interactable { get { return interactable; } set { interactable = value; } }

    UnityEvent<IResource> onPut = new(); public UnityEvent<IResource> OnPut { get { return onPut; } }

    UnityEvent<IResource> onTake = new(); public UnityEvent<IResource> OnTake { get { return onTake; } }

    public void InitiateWork()
    {
        throw new System.NotImplementedException();
    }

    public void PutOrTake()
    {
        if (operatable == null)
            return;
        else
        {
            Debug.Log("Put or Take");
            if (resource == null)
            {
                resource = operatable.Take();
                if (resource != null)
                {
                    Debug.Log("Get Item !!");
                    onTake.Invoke(resource);
                }
            }
            else
            {
                var isPut = operatable.Put(resource);
                if (isPut)
                {
                    resource = null;
                    onPut.Invoke(resource);
                }
            }
        }
        
    }

    public void Work()
    {
        throw new System.NotImplementedException();
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
