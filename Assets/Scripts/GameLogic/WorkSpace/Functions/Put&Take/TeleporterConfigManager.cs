using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Sync;

namespace GameLogic.WorkSpace
{
    public class TeleporterConfigManager : MonoBehaviour
    {
        [SerializeField] List<TeleporterPutAndTake> teleporterPutAndTakes;
        [SerializeField] List<ReceierPutAndTake> receiverPutAndTakes;
        [SerializeField] List<PlayerCustomPropertyCallback> customPropCallbacks;
        public PlayerPropertyKey[] sendItemKeys = new PlayerPropertyKey[4] { PlayerPropertyKey.from_player_1, PlayerPropertyKey.from_player_2, PlayerPropertyKey.from_player_3, PlayerPropertyKey.from_player_4 };
        public void SetPlayers()
        {
            //Debug.Log($"local player actor number {PhotonNetwork.LocalPlayer.ActorNumber}");
            var players = PhotonNetwork.PlayerList;
            //Debug.Log($"player count : {players.Length}");
            int increment = 0;
            for(int i = 0; i < players.Length; i++)
            {
                //Debug.Log($"======== i = {i} ========");
                if(i+1 == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    //Debug.Log($"actor number = {i + 1}, batting");
                    continue;
                }
                else
                {
                    //Debug.Log($"target actor  number {i + 1} in {PhotonNetwork.LocalPlayer.ActorNumber}");
                    //Debug.Log($"referenced actor number : {players[i].ActorNumber}");
                    teleporterPutAndTakes[increment].SetReceiver(players[i]);
                    receiverPutAndTakes[increment].SenderId = players[i].ActorNumber;
                    customPropCallbacks[increment].key = sendItemKeys[i];
                    increment++;
                }
            }
        }
    }
}
