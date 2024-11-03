using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace UI
{
    /// <summary>
    /// Written by Shinnosuke
    /// </summary>
    public class MatchingTextView : MonoBehaviour, ITextView<int>
    {
        [SerializeField] TextMeshProUGUI text;
        public void ShowText(int val)
        {
            text.text = "Matching Now ...\n" + PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " / " + PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        }
    }
}