using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using Photon.Realtime;

namespace GameLogic.WorkSpace
{
    public class Teleporter : MonoBehaviour,IOperatable,ISyncSender
    {
        Player receivier;
        public void InitiateOperation()
        {
            throw new System.NotImplementedException();
        }

        public bool Put(IGrabbable grabbable)
        {
            throw new System.NotImplementedException();
        }

        public void SetReceiver(Player player)
        {

        }

        public IGrabbable Take()
        {
            return null;
        }

        public void Work()
        {
            return;
        }
    }
}
