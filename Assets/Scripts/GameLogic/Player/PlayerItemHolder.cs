using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Player
{
    public class PlayerItemHolder : MonoBehaviour,IItemHolder
    {
        public void Grab(IResource grabbable)
        {
            throw new System.NotImplementedException();
        }

        public IResource Release()
        {
            throw new System.NotImplementedException();
        }
    }
}
