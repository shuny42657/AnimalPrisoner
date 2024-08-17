using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sync;
using GameLogic.GameSystem;

public class CustomPropertyCallbackPresenter : MonoBehaviour
{
    [SerializeField] RoomPredicatePropertyCallback callBack;
    JobAllocator jobAllocator = new JobAllocator();
    // Start is called before the first frame update
    void Start()
    {
        callBack.onModifiedWithMasterCleient.AddListener(() => jobAllocator.AllocateJob());
    }
}
