using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

public interface IOperatableHandler
{
    public IOperatable Operatable { get; set; }
    public IInteractable Interactable { get; set; }
    public void Put();
    public void Take();
    public void Work();
    public void InitiateWork();
}
