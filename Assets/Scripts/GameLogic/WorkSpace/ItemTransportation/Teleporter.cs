using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using Photon.Realtime;
using Photon.Pun;
using Sync;

namespace GameLogic.WorkSpace
{
    public class Teleporter : MonoBehaviour,IOperatable,ISyncSender
    {
        Player receivier;
        public bool Put(IResource resource)
        {
            if(receivier.GetSentItem(PhotonNetwork.LocalPlayer.ActorNumber) == -1)
            {
                receivier.SetSendItem(PhotonNetwork.LocalPlayer.ActorNumber,(int)resource.ItemName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetReceiver(Player player)
        {
            receivier = player;
        }

        public void InitiateOperation()
        {
            throw new System.NotImplementedException();
        }


        public bool Put(IGrabbable grabbable)
        {
            return false;
        }

        public IResource Take()
        {
            return null;
        }

        public void Work()
        {
            return;
        }
    }
}
