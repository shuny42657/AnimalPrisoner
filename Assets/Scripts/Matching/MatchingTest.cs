using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;

public class MatchingTest : MonoBehaviourPunCallbacks
{
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
        //////// 1�l�ł��ڑ�������J�ڂ��邩�̃e�X�g�@2�l�ȏ�̂Ƃ��̓R�����g�A�E�g
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                Debug.Log("Moving on to match");
                PhotonNetwork.LoadLevel("Teleporter(Copy)");
            }
        }
        ///////
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        /* 2�l�ȏ�̂Ƃ��̓R�����g�A�E�g���O��
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
                Debug.Log("Moving on to match");
                PhotonNetwork.LoadLevel("Teleporter(Copy)");
            }
        }
        */
    }
}
