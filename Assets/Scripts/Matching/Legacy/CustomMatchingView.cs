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
    public class CustomMatchingView : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private Button matchingButton;
        [SerializeField] string roomName = "Room";
        [SerializeField] int playerCount = 2;
        public void Setup()
        {
            matchingButton.interactable = false;
            passwordInputField.onValueChanged.AddListener(value => OnInputFieldValueChanged(value));
            matchingButton.onClick.AddListener(() => OnButtonClick());

        }
        public void OnButtonClick()
        {
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = playerCount;
            roomOptions.IsVisible = false;
            PhotonNetwork.JoinOrCreateRoom(passwordInputField.text, roomOptions, TypedLobby.Default);
        }
        public void OnInputFieldValueChanged(string value)
        {
            // can push button when pass is 6 digits
            matchingButton.interactable = (value.Length == 6);
        }
    }
}
