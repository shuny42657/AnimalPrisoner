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
    public class SignalReceiver : ISet
    {
        public UnityEvent<int> OnSenderIdSet;
        [SerializeField] int _senderId; public int SenderId { get { return _senderId; } set { _senderId = value; OnSenderIdSet.Invoke(_senderId); } }
        UnityEvent<ItemName> onSet = new(); public UnityEvent<ItemName> OnSet { get { return onSet; } }
        public SignalReceiver(int senderId)
        {
            _senderId = senderId;
        }
        public void Set()
        {
            var _itemName = (ItemName)PhotonNetwork.LocalPlayer.GetSentSignal(_senderId);
            Debug.Log($"Signal Receiver Set Called : {(ItemName)_itemName}");
            onSet.Invoke(_itemName);
        }
    }
}
