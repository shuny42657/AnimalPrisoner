using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterInputController : MonoBehaviour, IKeyInputController
{
    UnityEvent<float> onHAxis = new(); public UnityEvent<float> OnHAxis { get { return onHAxis; } }

    UnityEvent<float> onVAxis = new(); public UnityEvent<float> OnVAxis { get { return onVAxis; } }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0f)
        {
            onHAxis.Invoke(Input.GetAxisRaw("Horizontal"));
        }

        if(Input.GetAxisRaw("Vertical") != 0f)
        {
            onVAxis.Invoke(Input.GetAxisRaw("Vertical"));
        }
    }
}
