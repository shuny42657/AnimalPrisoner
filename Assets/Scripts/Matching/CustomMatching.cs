using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

namespace Matching
{
    /// <summary>
    /// Written by Shinnosuke (2024/09/11)
    /// </summary>
    public class CustomMatching : MonoBehaviourPunCallbacks, IMatching
    {
        [SerializeField] int playerCount = 2;
        private string password;
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
            roomOptions.IsVisible = false;
            PhotonNetwork.JoinOrCreateRoom(password, roomOptions, TypedLobby.Default);
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
    }
}
