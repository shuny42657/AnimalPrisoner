using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace Matching
{
    /// <summary>
    /// Written by Shinnosuke (2024/09/11)
    /// </summary>
    public class RandomMatching : MonoBehaviourPunCallbacks, IMatching
    {
        [SerializeField] string roomName = "Room";
        [SerializeField] int playerCount = 2;
        [SerializeField] MatchingCallback matchingCallback;
        public void ConnectToMasterServer()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
        public void RegisterCallback()
        {
            matchingCallback.onConnectedToMaster.AddListener(() => StartMatching());
        }
        public void StartMatching()
        {
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = playerCount;
            roomOptions.IsVisible = true;
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        }
        public void DisconnectMatching()
        {
            PhotonNetwork.Disconnect();
        }
    }
}