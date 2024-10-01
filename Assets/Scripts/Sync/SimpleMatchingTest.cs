using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SimpleMatchingTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
//        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
    }
}
