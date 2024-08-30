using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace Matching
{
    public class RandomMatching : MonoBehaviourPunCallbacks, IMatching
    {
        [SerializeField] string roomName = "Room";
        [SerializeField] int playerCount = 2;
        public void StartMatching()
        {
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = playerCount;
            roomOptions.IsVisible = true;
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        }
    }
}