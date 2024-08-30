using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

namespace Matching
{
    public class CustomMatching : MonoBehaviourPunCallbacks, IMatching
    {
        [SerializeField] int playerCount = 2;
        [SerializeField] TMP_InputField passwordInputField;
        public void StartMatching()
        {
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = playerCount;
            roomOptions.IsVisible = false;
            PhotonNetwork.JoinOrCreateRoom(passwordInputField.text, roomOptions, TypedLobby.Default);
        }
    }
}
