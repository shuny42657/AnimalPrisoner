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

public class SignalViewerFactory : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke (2024/11/7)
    /// </summary>
    [SerializeField] SignalViewer signalViewerPrefab;
    [SerializeField] public ItemDataBase itemDataBase;
    Dictionary<ItemName, SignalViewer> signalViewerDictionary = new();
    [SerializeField] Transform parentTransform;
    public void Generate(ItemName itemName)
    {
        var newSignal = Instantiate(signalViewerPrefab, parentTransform);
        var signalName = itemName;
        newSignal.ItemImage.SetImage(itemDataBase.GetData(signalName).SourceImage);
        //if (!signalViewerDictionary.ContainsKey(signalName))
        //{
        //    signalViewerDictionary.Add(signalName, newSignal);
        //}
        signalViewerDictionary.Add(signalName, newSignal);  // シグナルが重複するとエラーが出る（ゲーム上は正常作動）ため要検討
    }
    public void DeleteViewer(ItemName itemName)
    {
        if (signalViewerDictionary.ContainsKey(itemName))
        {
            Destroy(signalViewerDictionary[itemName].gameObject);
            signalViewerDictionary.Remove(itemName);
        }
    }
}
