using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMotherFactory<T,S> where T : System.Enum
{
    public S Generate(T name);
}
