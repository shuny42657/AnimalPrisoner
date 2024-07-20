using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Player
{
    public interface IItemHolder 
    {
        public void Grab(IResource grabbable);
        public IResource Release();
    }
}
