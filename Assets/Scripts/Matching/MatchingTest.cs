using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MatchingTest : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke
    /// </summary>
    public string playerName;
    public void Awake()
    {
        PhotonNetwork.NickName = playerName;
    }
    public void DisplayPlayerList()
    {
        Debug.Log("after: " + PhotonNetwork.PlayerList[0].NickName);
    }
}
