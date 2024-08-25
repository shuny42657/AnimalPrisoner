using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Realtime;
using Photon.Pun;
using Sync;

namespace GameLogic.WorkSpace
{
    public class ReceierPutAndTake : MonoBehaviourPunCallbacks,IPutAndTake,ISet
    {
        public UnityEvent<int> OnSenderIdSet;
        [SerializeField] int senderId; public int SenderId { get { return senderId; } set { senderId = value;OnSenderIdSet.Invoke(senderId); } }
        ItemName itemName;
        public ItemName Item => throw new System.NotImplementedException();

        [SerializeField] UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        [SerializeField] UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        UnityEvent<ItemName> onSet = new();public UnityEvent<ItemName> OnSet { get { return onSet; } }

        public bool Put(ItemName itemName)
        {
            return false;
        }

        public void Set(ItemName itemName)
        {
            if(this.itemName == ItemName.None)
            {
                this.itemName = itemName;
                Debug.Log($"Item Name : {itemName}");
                onPut.Invoke(itemName);
            }
        }

        public ItemName Take()
        {
                var temp = itemName;
                Debug.Log($"temp : {temp}");
                itemName = ItemName.None;
                PhotonNetwork.LocalPlayer.SetSendItem(senderId, (int)ItemName.None);
                onTake.Invoke();
                return temp;
        }

        public void SetReceivedItem()
        {
            Debug.Log("Set");
            Set((ItemName)PhotonNetwork.LocalPlayer.GetSentItem(senderId));
        }
    }
}
