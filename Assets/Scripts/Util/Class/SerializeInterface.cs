using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializeInterface<T>
{
    [SerializeField] GameObject obj;
    T value;

    public T Value
    {
        get
        {
            value ??= obj.GetComponent<T>();
            return value;
        }
    }
}
