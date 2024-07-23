using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using GameLogic.WorkSpace;


public class P_Player_OperatableCallback : MonoBehaviour
{
    [SerializeField] SerializeInterface<IOperatableCallback> operatableCallback;
    [SerializeField] SerializeInterface<IGrabbableVisualizer> visualizer;
    // Start is called before the first frame update

    private void Awake()
    {
        operatableCallback.Value.OnPut.AddListener((resource) => visualizer.Value.Delete());
        operatableCallback.Value.OnTake.AddListener((resource) => visualizer.Value.Show(resource.ItemName));
    }
}
