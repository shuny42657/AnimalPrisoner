using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;
using GameLogic.Data;
using Photon.Pun;
using Photon.Realtime;

public class SignalViewerFactory : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke (2024/11/7)
    /// </summary>
    [SerializeField] SignalViewer signalViewerPrefab;
    [SerializeField] public ItemDataBase itemDataBase;
    Dictionary<ItemName, SignalViewer> signalViewerDictionary = new();
    [SerializeField] PhotonView photonView;
    public void Generate(ItemName itemName, Transform parentTransform)
    {
        var newSignal = Instantiate(signalViewerPrefab, parentTransform);
        newSignal.ItemImage.SetImage(itemDataBase.GetData(itemName).SourceImage);
        signalViewerDictionary.Add(itemName, newSignal);
    }
    public void DeleteViewer(ItemName itemName)
    {
        if (signalViewerDictionary.ContainsKey(itemName))
        {
            Destroy(signalViewerDictionary[itemName].gameObject);
            signalViewerDictionary.Remove(itemName);
        }
    }
    public void GenerateOther(int itemName)
    {
        photonView.RPC("RpcGenerate", RpcTarget.All, PhotonNetwork.LocalPlayer, itemName);
    }
    [PunRPC]
    private void RpcGenerate(Player player, ItemName itemName)
    {
        var playerInfoViewers = FindObjectsOfType<PlayerInfoViewer>();
        foreach (var piv in playerInfoViewers)
        {
            if (piv.ActorNumber == player.ActorNumber)
            {
                var parentTransform = piv.gameObject.GetComponentInChildren<HorizontalLayoutGroup>().transform;
                Generate(itemName, parentTransform);
                break;
            }
        }
    }
}
