using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;
using Sync;

namespace GameLogic.WorkSpace
{
    // Item Dissappear after put. Could be resued for sumbmission space ?
    public class TeleporterPutAndTake : IPutAndTake
    {
        Player _receiver;
        int _receiverID;

        UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        public TeleporterPutAndTake(Player receiver)
        {
            _receiver = receiver;
            _receiverID = receiver.ActorNumber;
        }

        public bool Put(ItemName itemName)
        {
            Debug.Log(_receiver.GetSentItem(PhotonNetwork.LocalPlayer.ActorNumber));
            if(_receiver.GetSentItem(PhotonNetwork.LocalPlayer.ActorNumber) == (int)ItemName.None)
            {
                Debug.Log($"Put {itemName} on Teleporter to {_receiverID}");
                _receiver.SetSendItem(PhotonNetwork.LocalPlayer.ActorNumber, (int)itemName);
                Debug.Log($"receiver.GetSentItem() : {_receiver.GetSentItem(PhotonNetwork.LocalPlayer.ActorNumber)}");
                onPut.Invoke(itemName);
                return true;
            }
            else
            {
                Debug.Log("Not on Teleporter");
                return false;
            }
        }

        public ItemName Take()
        {
            return ItemName.None;
        }
    }
}
