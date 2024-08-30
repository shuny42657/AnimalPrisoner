using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;
using UI;

namespace Matching
{
    public class MatchingCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] SerializeInterface<IScene> matchingScene;
        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to master server");
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log($"Disconnected: {cause.ToString()}");
        }
        public override void OnCreatedRoom()
        {
            Debug.Log("Room created");
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("Joined room");
            if (PhotonNetwork.IsMasterClient)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
                {
                    matchingScene.Value.LoadScene();
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
                    matchingScene.Value.LoadScene();
                }
            }
        }
    }
}
