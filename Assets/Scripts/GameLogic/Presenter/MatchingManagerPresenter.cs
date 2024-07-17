using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Factory;
using Sync;

public class MatchingManagerPresenter : MonoBehaviour
{
    [SerializeField] SerializeInterface<IPlayerFactory> factory;
    [SerializeField] SerializeInterface<IMatchinCallback> matchingCallback;

    private void Awake()
    {
        matchingCallback.Value.OnRoomJoined.AddListener(() => factory.Value.GeneratePlayer(new Vector3(0, 0, 0)));
    }
}
