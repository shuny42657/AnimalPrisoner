using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterInputController : MonoBehaviour, IKeyInputController
{
    [SerializeField] UnityEvent<float> onHAxis = new(); public UnityEvent<float> OnHAxis { get { return onHAxis; } }

    [SerializeField] UnityEvent<float> onVAxis = new(); public UnityEvent<float> OnVAxis { get { return onVAxis; } }
    [SerializeField] UnityEvent onEPressed = new(); public UnityEvent OnEPressed { get { return onEPressed; } }
    [SerializeField] UnityEvent onQ = new(); public UnityEvent OnQ { get { return onQ; } }
    [SerializeField] UnityEvent onFPressed = new();public UnityEvent OnFPressed { get { return onFPressed; } }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0f)
        {
            Debug.Log("Hori");
            onHAxis.Invoke(Input.GetAxisRaw("Horizontal"));
        }

        if(Input.GetAxisRaw("Vertical") != 0f)
        {
            Debug.Log("Verti");
            onVAxis.Invoke(Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            onEPressed.Invoke();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Q");
            onQ.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F pressed");
            onFPressed.Invoke();
        }
    }
}
