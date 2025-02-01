using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISetter<T>
{
    public bool Value { set;}
}

public interface IGetter<T> 
{
    public bool Value { get; }
}

