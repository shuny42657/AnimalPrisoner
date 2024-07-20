using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public interface IMotherFactory<T,S> where T : System.Enum
    {
        public S Generate(T name, Vector3 position);
    }
}
