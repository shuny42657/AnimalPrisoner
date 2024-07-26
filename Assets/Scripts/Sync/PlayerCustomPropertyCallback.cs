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
        [SerializeField] bool showLog;
        public PlayerPropertyKey key;
        public UnityEvent onComplete = new();
        public UnityEvent onCompleteWithMasterClient = new();

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
        {
            //Debug.Log($"Target player : {targetPlayer.ActorNumber}",gameObject);
            /*if (showLog)
            {
                //Debug.Log("Show Log = True");
                foreach(var p in changedProps.Keys)
                {
                    //Debug.Log($"{p} changed");
                        //Debug.Log($"Jd : {PhotonNetwork.LocalPlayer.GetJobDetermined()}");
                }
            }*/

            if (changedProps.ContainsKey(key.ToString()))
            {
                if(targetPlayer == PhotonNetwork.LocalPlayer)
                {
                    if(showLog)
                        Debug.Log($"Key : {key}");
                    onComplete.Invoke();
                    if (PhotonNetwork.IsMasterClient)
                    {
                        if (showLog)
                            Debug.Log("Matching Complete");
                        onCompleteWithMasterClient.Invoke();
                    }
                }
            }
        }
    }
}

