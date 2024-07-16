using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Map
{
    public interface IFactory<T>
    {
        public T GenerateWorkSpace(Vector3 position); 
    }
}
