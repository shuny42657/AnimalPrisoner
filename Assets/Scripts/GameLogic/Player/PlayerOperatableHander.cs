using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

public class PlayerOperatableHander : MonoBehaviour, IOperatableHandler
{
    IOperatable operatable;
    IInteractable interactable;
    public IOperatable Operatable { get { return operatable; } set { operatable = value; Debug.Log($"Operatable : {operatable}"); } }

    public IInteractable Interactable { get { return interactable; } set { interactable = value; } }

    public void InitiateWork()
    {
        throw new System.NotImplementedException();
    }

    public void Put()
    {
        throw new System.NotImplementedException();
    }

    public void Take()
    {
        throw new System.NotImplementedException();
    }

    public void Work()
    {
        throw new System.NotImplementedException();
    }
}
