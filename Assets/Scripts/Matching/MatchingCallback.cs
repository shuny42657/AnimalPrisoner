using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;
using UI;

namespace Matching
{
    /// <summary>
    /// Written by Shinnosuke
    /// </summary>
    public class MatchingCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] public UnityEvent onConnectedToMaster;
        [SerializeField] public UnityEvent onDisconnected;
        [SerializeField] public UnityEvent onCreatedRoom;
        [SerializeField] public UnityEvent onJoinedRoom;
        [SerializeField] public UnityEvent onPlayerEnteredRoom;
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to master server");
            onConnectedToMaster.Invoke();
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Disconnected: {cause.ToString()}");
            onDisconnected.Invoke();
        }
        public override void OnCreatedRoom()
        {
            Debug.Log("Room created");
            onCreatedRoom.Invoke();
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("Joined room");
            if (PhotonNetwork.IsMasterClient)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
                {
                    onJoinedRoom.Invoke();
                }
            }
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log("Joined room");
            if (PhotonNetwork.IsMasterClient)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
                {
                    onPlayerEnteredRoom.Invoke();
                }
            }
        }
    }
}
