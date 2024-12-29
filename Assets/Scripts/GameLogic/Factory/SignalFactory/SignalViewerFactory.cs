using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UI;
using GameLogic.Data;
using GameLogic.GameSystem;
using Photon.Pun;
using Photon.Realtime;
using Sync;
using Cysharp.Threading.Tasks;
using System;

public class SignalViewerFactory : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke (2024/11/7)
    /// </summary>
    [SerializeField] SignalViewer signalViewerPrefab;
    [SerializeField] public ItemDataBase itemDataBase;
    Dictionary<ItemName, SignalViewer> signalViewerDictionary = new();
    [SerializeField] Transform parentTransform;
    [SerializeField] int deleteTime;
    public void Generate(ItemName itemName)
    {
        if (!signalViewerDictionary.ContainsKey(itemName))
        {
            var newSignal = Instantiate(signalViewerPrefab, parentTransform);
            newSignal.ItemImage.SetImage(itemDataBase.GetData(itemName).SourceImage);
            signalViewerDictionary.Add(itemName, newSignal);
        }
    }
    public void DeleteViewer(ItemName itemName)
    {
        if (signalViewerDictionary.ContainsKey(itemName))
        {
            Destroy(signalViewerDictionary[itemName].gameObject);
            signalViewerDictionary.Remove(itemName);
        }
    }

    public async UniTask RunDeleteViewerProcess(ItemName itemName)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(deleteTime));
        DeleteViewer(itemName);
    }
}
