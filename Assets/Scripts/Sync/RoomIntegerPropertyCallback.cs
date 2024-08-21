using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

namespace Sync
{
    public class RoomIntegerPropertyCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] RoomPropertyKey key;
        public UnityEvent<int> onModified = new();
        public UnityEvent<int> onModifiedWithMasterClieent = new();
        // Start is called before the first frame update

        public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
        {
            if (propertiesThatChanged.ContainsKey(key.ToString()))
            {
                var val = (int)(PhotonNetwork.CurrentRoom.CustomProperties[key.ToString()]);
                onModified.Invoke(val);
                if (PhotonNetwork.IsMasterClient)
                {
                    onModifiedWithMasterClieent.Invoke(val);
                }
            }
        }
    }
}
