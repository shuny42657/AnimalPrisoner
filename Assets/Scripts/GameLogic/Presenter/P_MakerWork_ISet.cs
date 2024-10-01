using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using GameLogic.WorkSpace;
using Util;

public class P_MakerWork_ISet : MonoBehaviour
{
    [SerializeField] SerializeInterface<MakerWork> work;
    [SerializeField] SerializeInterface<ISet> putAndTake;

    private void Awake()
    {
        work.Value.OnWorkFinish.AddListener((itemName) => putAndTake.Value.Set(itemName));
    }
}
