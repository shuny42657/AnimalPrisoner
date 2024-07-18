using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;
using Photon.Realtime;

namespace Sync
{
    public class PlayerCustomPropertyCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] PlayerPropertyKey key;
        public UnityEvent onComplete = new();
        public UnityEvent onCompleteWithMasterClient = new();

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        {
            if (changedProps.ContainsKey(key.ToString()))
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

