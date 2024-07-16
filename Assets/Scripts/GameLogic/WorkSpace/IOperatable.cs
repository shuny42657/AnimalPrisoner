using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameLogic.WorkSpace
{
    public interface IOperatable
    {
        public bool Put(IGrabbable grabbable);
        public IGrabbable Take();
        public void Work();
        public void InitiateOperation();
    }
}
