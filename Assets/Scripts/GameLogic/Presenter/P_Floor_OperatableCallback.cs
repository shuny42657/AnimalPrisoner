using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using GameLogic.Map;
using Util;

public class P_Floor_OperatableCallback : MonoBehaviour
{
    [SerializeField]SerializeInterface<IOperatableCallback> operatableCallback;
    [SerializeField]GrabbableVisualizer visualizer;

    private void Awake()
    {
        operatableCallback.Value.OnPut.AddListener((resource) => visualizer.Show(resource.ItemName));
        operatableCallback.Value.OnTake.AddListener((resource) => visualizer.Delete());
    }
}
