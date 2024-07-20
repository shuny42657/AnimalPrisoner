using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public interface IFactory<T>
    {
        public T GenerateItem(Vector3 position); 
    }
}
