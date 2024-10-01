using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using GameLogic.Factory;
using GameLogic.GameSystem;
using Sync;

public class GameStarter : MonoBehaviour
{
    [SerializeField] SerializeInterface<IPlayerFactory> factory;
    //[SerializeField] RoomCustomPropertyCallback callback;
    JobAllocator jobAllocator = new JobAllocator();
    private void Start()
    {
        factory.Value.GeneratePlayer(new Vector3(0, 0, 0));
        PhotonNetwork.CurrentRoom.SetMatchComplete(true);
        //callback.onModifiedWithMasterCleient.AddListener(() => jobAllocator.AllocateJob());
    }
}
