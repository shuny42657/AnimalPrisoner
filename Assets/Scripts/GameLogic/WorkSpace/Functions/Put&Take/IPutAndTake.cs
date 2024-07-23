using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public interface IPutAndTake
    {
        public bool Put(IResource resource);
        public IResource Take();

        public IResource Resource { get; }

        public UnityEvent<IResource> OnPut { get; }
        public UnityEvent OnTake { get; }
    }

    public interface IWork
    {
        public void Work();
    }

    public interface IAutomatable
    {
        public void InitateOperation();
    }
}
