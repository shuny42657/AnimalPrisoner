using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.Events;

namespace Sync
{
    public class RoomPredicatePropertyCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] RoomPropertyKey key;
        public UnityEvent onModified = new();
        public UnityEvent onModifiedWithMasterCleient = new();

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            if (propertiesThatChanged.ContainsKey(key.ToString()))
            {
                var yes = (bool)(PhotonNetwork.CurrentRoom.CustomProperties[key.ToString()]);
                if (yes)
                {
                    Debug.Log("Predicate Callback Invoked");
                    onModified.Invoke();
                    if (PhotonNetwork.IsMasterClient)
                    {
                        //Debug.Log("Matching Complete");
                        onModifiedWithMasterCleient.Invoke();
                    }
                }
            }
        }
    }
}
