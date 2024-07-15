using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameLogic.WorkSpace
{
    public interface IOperatable
    {
        public void Put(IGrabbable grabbable);
        public IGrabbable Take();
        public void Work();
        public void Start();
    }
}
