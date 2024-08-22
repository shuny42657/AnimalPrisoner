using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sync;
using GameLogic.GameSystem;

public class CustomPropertyCallbackPresenter : MonoBehaviour
{
    [SerializeField] RoomPredicatePropertyCallback callBack;
    [SerializeField] int allocatorID;
    IJobAllocator jobAllocator = new MainJobAllocator();
    // Start is called before the first frame update
    void Start()
    {
        switch (allocatorID)
        {
            case 0:
                jobAllocator = new SimpleJobAllocator();
                break;
            case 1:
                jobAllocator = new MainJobAllocator();
                break;
            default:
                jobAllocator = new MainJobAllocator();
                break;
        }
        callBack.onModifiedWithMasterCleient.AddListener(() => jobAllocator.AllocateJob());
    }
}
