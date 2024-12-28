using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UI;
using Sync;

public class SignalDisplay : MonoBehaviour
{
    //[SerializeField] SignalViewerFactory signalViewerFactory;
    //[SerializeField] PhotonView photonView;
    //public void GenerateOther(int itemName)
    //{
    //    photonView.RPC("RpcGenerate", RpcTarget.All, PhotonNetwork.LocalPlayer, itemName);
    //}
    //[PunRPC]
    //private void RpcGenerate(Player player, ItemName itemName)
    //{
    //    var playerInfoViewers = FindObjectsOfType<PlayerInfoViewer>();
    //    foreach (var piv in playerInfoViewers)
    //    {
    //        if (piv.ActorNumber == player.ActorNumber)
    //        {
    //            var parentTransform = piv.gameObject.GetComponentInChildren<HorizontalLayoutGroup>().transform;
    //            signalViewerFactory.Generate(itemName, parentTransform);
    //            break;
    //        }
    //    }
    //}

    //public void Show(ItemName itemName)
    //{

    //}

    //public ItemName Take()
    //{
    //    return ItemName.None;
    //}
}
