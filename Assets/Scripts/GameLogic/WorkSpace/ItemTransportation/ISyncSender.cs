using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

namespace GameLogic.WorkSpace
{
    public interface ISyncSender
    {
        public void SetReceiver(Player player);
    }
}
