using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class StoneMaker : MonoBehaviour, IOperatable
    {
        public bool Put(IGrabbable grabbable)
        {
            throw new NotImplementedException();
        }

        public void InitiateOperation()
        {
            throw new NotImplementedException();
        }

        public IResource Take()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            throw new NotImplementedException();
        }

        public bool Put(IResource recource)
        {
            throw new NotImplementedException();
        }
    }
}
