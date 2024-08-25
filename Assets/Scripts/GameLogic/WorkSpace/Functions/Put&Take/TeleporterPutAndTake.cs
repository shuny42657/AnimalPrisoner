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
    public class TeleporterPutAndTake : MonoBehaviour,IPutAndTake
    {
        Player receiver;
        int receiverID;
        ItemName itemName = ItemName.None;
        public ItemName Item { get { return itemName; } }

        public UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        public UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        public void SetReceiver(Player player)
        {
            receiver = player;
            receiverID = player.ActorNumber;
            OnReceiverIDSet.Invoke(receiverID);
        }
        public UnityEvent<int> OnReceiverIDSet;
        
        public bool Put(ItemName itemName)
        {
            Debug.Log(receiver.GetSentItem(PhotonNetwork.LocalPlayer.ActorNumber));
            if(receiver.GetSentItem(PhotonNetwork.LocalPlayer.ActorNumber) == (int)ItemName.None)
            {
                Debug.Log($"Put on Teleporter to {receiver.ActorNumber}");
                receiver.SetSendItem(PhotonNetwork.LocalPlayer.ActorNumber, (int)itemName);
                //Debug.Log($"Receiver : {receiver.ActorNumber}");
                Debug.Log($"receiver.GetSentItem() : {receiver.GetSentItem(PhotonNetwork.LocalPlayer.ActorNumber)}");
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
