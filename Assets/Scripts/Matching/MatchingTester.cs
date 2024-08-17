using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class MatchingTester : MonoBehaviour
{
    [SerializeField] Button matchingButton;
    [SerializeField] string roomName = "Room";
    [SerializeField] int playerCount = 2;
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }
    void Start()
    {
        matchingButton.onClick.AddListener(() => OnMatchingButtonClick(roomName));
    }

    public void OnMatchingButtonClick(string roomName)
    {
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = playerCount;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }
}
