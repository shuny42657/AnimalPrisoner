using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using GameLogic.WorkSpace;
using GameLogic.Map;

public class P_PutAndTake_Visualizer: MonoBehaviour
{
    [SerializeField] SerializeInterface<IPutAndTake> putAndTake;
    [SerializeField] SerializeInterface<IGrabbableVisualizer> visualizer;

    private void Awake()
    {
        putAndTake.Value.OnPut.AddListener((resource) => visualizer.Value.Show(resource.ItemName));
        putAndTake.Value.OnTake.AddListener(() => visualizer.Value.Delete());
    }
}
