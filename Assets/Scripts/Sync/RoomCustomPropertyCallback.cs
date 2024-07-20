using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.Events;

namespace Sync
{
    public class RoomCustomPropertyCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] RoomPropertyKey key;
        public UnityEvent onComplete = new();
        public UnityEvent onCompleteWithMasterClient = new();

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            if (propertiesThatChanged.ContainsKey(key.ToString()))
            {
                onComplete.Invoke();
                if (PhotonNetwork.IsMasterClient)
                {
                    Debug.Log("Matching Complete");
                    onCompleteWithMasterClient.Invoke();
                }
            }
        }
    }
}
