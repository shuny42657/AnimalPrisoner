using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IKeyInputController
{
    public UnityEvent<float> OnHAxis { get; }
    public UnityEvent<float> OnVAxis { get; }
    public UnityEvent OnEPressed { get; }
    public UnityEvent OnQ { get; }
}
