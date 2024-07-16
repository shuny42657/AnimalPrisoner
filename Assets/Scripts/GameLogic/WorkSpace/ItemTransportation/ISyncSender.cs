using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

namespace GameLogic.WorkSpace
{
    public interface ISyncSender
    {
        public void SetReceiver(Player player);
    }
}
