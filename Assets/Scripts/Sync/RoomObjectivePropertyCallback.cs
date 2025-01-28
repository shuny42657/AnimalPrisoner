using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.Events;

namespace Sync
{
    public class RoomObjectivePropertyCallback : MonoBehaviourPunCallbacks
    {
        public UnityEvent<int> onModified = new();
        public UnityEvent<int> onModifiedWithMasterClieent = new();

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            string prefix = "obj_";
            var matchingKeys = propertiesThatChanged.Keys
                                                    .Where(key => key.ToString().StartsWith(prefix));
            foreach (var key in matchingKeys)
            {
                var val = (int)(PhotonNetwork.CurrentRoom.CustomProperties[key]);
                onModified.Invoke(val);
                if (PhotonNetwork.IsMasterClient)
                {
                    onModifiedWithMasterClieent.Invoke(val);
                }
            }
        }
    }
}
