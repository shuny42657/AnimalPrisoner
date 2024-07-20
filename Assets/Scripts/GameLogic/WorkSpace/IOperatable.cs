using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public interface IOperatable
    {
        public bool Put(IGrabbable grabbable);
        public bool Put(IResource recource);
        public IResource Take();
        public void Work();
        public void InitiateOperation();
    }

    public interface IOperatableCallback
    {
        public UnityEvent<IResource> OnPut { get; }
        public UnityEvent<IResource> OnTake { get; }
    }
}
