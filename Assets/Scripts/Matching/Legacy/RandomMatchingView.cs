using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using UI;

namespace Matching
{
    public class RondomMatchingView : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button matchingButton;
        [SerializeField] string roomName = "Room";
        [SerializeField] int playerCount = 2;
        public void Setup()
        {
            matchingButton.interactable = true;
            matchingButton.onClick.AddListener(() => OnButtonClick());
        }
        public void OnButtonClick()
        {
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = playerCount;
            roomOptions.IsVisible = true;
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        }
    }
}