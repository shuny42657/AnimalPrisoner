using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameLogic.WorkSpace;
using Photon.Realtime;
using Photon.Pun;
using Sync;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// Written by Shinnosuke (2024/12)
    /// </summary>
    public class SignalSender : MonoBehaviour
    {
        UnityEvent<int> onSet = new(); public UnityEvent<int> OnSet { get { return onSet; } }
        public void Set(int itemName)
        {
            var players = PhotonNetwork.PlayerList;
            if (players.Length == 1)
            {
                return;
            }
            else
            {
                foreach (var player in players)
                {
                    if (player == PhotonNetwork.LocalPlayer)
                    {
                        continue;
                    }
                    else
                    {
                        player.SetSendSignal(PhotonNetwork.LocalPlayer.ActorNumber, (int)itemName);
                        Debug.Log($"Signal Sender Set Called : {(ItemName)itemName}");
                        onSet.Invoke(itemName);
                    }
                }
            }
        }
    }
}
