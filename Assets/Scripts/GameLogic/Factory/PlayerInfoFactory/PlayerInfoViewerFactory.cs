using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerInfoViewerFactory : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke (2024/11/7)
    /// </summary>
    [SerializeField] PlayerInfoViewer playerInfoViewerPrefab;
    [SerializeField] Transform parentTransform;
    [SerializeField] PhotonView photonView;
    public void Generate(Player player)
    {
        var newPlayerInfo = Instantiate(playerInfoViewerPrefab, parentTransform);
        //var icon = 
        //var nameplate = 
        var name = player.NickName;
        newPlayerInfo.ActorNumber = player.ActorNumber;
        newPlayerInfo.PlayerName.SetText(name);
        //newPlayerInfo.PlayerIcon.SetImage(icon);
        //newPlayerInfo.PlayerNameplate.SetImage(nameplate);
    }
    public void GenerateOther()
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            photonView.RPC("RpcGenerate", RpcTarget.AllBuffered, player);
        }
    }
    [PunRPC]
    private void RpcGenerate(Player player)
    {
        if (player.ActorNumber != PhotonNetwork.LocalPlayer.ActorNumber)
        {
            Generate(player);
        }
    }
}
