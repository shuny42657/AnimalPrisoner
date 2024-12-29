using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using GameLogic.WorkSpace;
using GameLogic.GameSystem;
using Util;
using UI;
using Sync;

public class SignalReceiverFactory
{
    /// <summary>
    /// Written by Shinnosuke (2024/12)
    /// </summary>
    PlayerCustomPropertyCallback _playerCustomPropCallback;
    int _senderId;

    public SignalReceiverFactory(
        PlayerCustomPropertyCallback playerCustomPropCallback,
        int senderId
        )
    {
        _playerCustomPropCallback = playerCustomPropCallback;
        _senderId = senderId;
    }

    public SignalReceiver GenerateSignalReceiver(SignalViewerFactory signalViewerFactory)
    {
        var signalReceiver = new SignalReceiver(_senderId);
        _playerCustomPropCallback.onComplete.AddListener(() => signalReceiver.Set());
        signalReceiver.OnSet.AddListener((itemName) => signalViewerFactory.Generate(itemName));
        signalReceiver.OnSet.AddListener((itemName) => signalViewerFactory.RunDeleteViewerProcess(itemName));
        return signalReceiver;
    }
}
