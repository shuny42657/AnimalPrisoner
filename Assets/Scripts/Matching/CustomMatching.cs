using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

namespace Matching
{
    /// <summary>
    /// Written by Shinnosuke
    /// </summary>
    public class CustomMatching : MonoBehaviourPunCallbacks, IMatching
    {
        [SerializeField] int playerCount = 2;
        private string password;
        public void StartMatching()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
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
