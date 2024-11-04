using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Realtime;
using Photon.Pun;
using Sync;
using Cysharp.Threading.Tasks;

namespace GameLogic.WorkSpace
{
    public class ReceierPutAndTake : IPutAndTake,ISet
    {
        public UnityEvent<int> OnSenderIdSet;
        [SerializeField] int _senderId; public int SenderId { get { return _senderId; } set { _senderId = value;OnSenderIdSet.Invoke(_senderId); } }

        ItemName _itemName;

        [SerializeField] UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        [SerializeField] UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        UnityEvent<ItemName> onSet = new();public UnityEvent<ItemName> OnSet { get { return onSet; } }

        public ReceierPutAndTake(int senderId)
        {
            _senderId = senderId;
        }

        public bool Put(ItemName itemName)
        {
            return false;
        }

        public void Set()
        {
            var _itemName = (ItemName)PhotonNetwork.LocalPlayer.GetSentItem(_senderId);
            Debug.Log($"Receiver Set Called : {_itemName}");
            onSet.Invoke(_itemName);
            Debug.Log($"Receiver Set Called : {_itemName}");
        }

        public async void Set(ItemName itemName)
        {
            if(_itemName == ItemName.None)
            {
                _itemName = itemName;
                Debug.Log($"Item Name : {itemName}");
                onPut.Invoke(itemName);
                await UniTask.WaitForSeconds(5000);
                Debug.Log($"Item Name : {itemName}");
            }
        }

        public ItemName Take()
        {
            /*Debug.Log($"Taken _itemName : {_itemName}");
            Debug.Log($"Item at Custom Property {(ItemName)PhotonNetwork.LocalPlayer.GetSentItem(_senderId)}");
            var temp = _itemName;
            Debug.Log($"temp : {temp}");
            PhotonNetwork.LocalPlayer.SetSendItem(_senderId, (int)ItemName.None);
            _itemName = ItemName.None;
            onTake.Invoke();
            return temp;*/

            var temp = (ItemName)PhotonNetwork.LocalPlayer.GetSentItem(_senderId);
            _itemName = ItemName.None;
            PhotonNetwork.LocalPlayer.SetSendItem(_senderId, (int)ItemName.None);
            onTake.Invoke();
            return temp;
        }
    }
}
