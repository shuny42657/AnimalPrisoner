using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyHoldController : MonoBehaviour
{
    [SerializeField] KeyCode key;
    public UnityEvent OnKeyHold;

    private void Update()
    {
        if (Input.GetKey(key))
        {
            OnKeyHold.Invoke();
        }
    }
}
