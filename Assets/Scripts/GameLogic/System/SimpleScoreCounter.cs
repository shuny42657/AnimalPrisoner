using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Sync;
using Photon.Realtime;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public class SimpleScoreCounter : MonoBehaviourPunCallbacks,IScoreCounter
    {
        Room room;
        public void AddItem(ItemName itemName)
        {
            if (room == null)
                room = PhotonNetwork.CurrentRoom;
            room.AddScore(10);
        }

        public int GetScore()
        {
            if (room == null)
                room = PhotonNetwork.CurrentRoom;
            return room.GetScore();
        }

        public UnityEvent<int> onScoreModified;
        public void ModifySocre()
        {
            onScoreModified.Invoke(GetScore());
        }
    }
}
