using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

namespace GameLogic.WorkSpace
{
    public class Receiver : MonoBehaviour, IOperatable
    {
        public void InitiateOperation()
        {
            throw new System.NotImplementedException();
        }

        public bool Put(IGrabbable grabbable)
        {
            throw new System.NotImplementedException();
        }

        public bool Put(IResource recource)
        {
            throw new System.NotImplementedException();
        }

        public IResource Take()
        {
            throw new System.NotImplementedException();
        }

        public void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}
