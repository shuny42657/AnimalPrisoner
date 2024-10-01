using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;
using Util;
using GameLogic.GameSystem;
using Sync;

namespace GameLogic.WorkSpace
{
    public class SubmissionPutAndTake : MonoBehaviour, IPutAndTake
    {
        [SerializeField] SerializeInterface<IScoreCounter> scoreCounter;
        public ItemName Item { get { return ItemName.None; } }

        UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

        UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }

        public bool Put(ItemName itemName)
        {
            scoreCounter.Value.AddItem(itemName);
            onPut.Invoke(itemName);
            return true;
        }

        public ItemName Take()
        {
            return ItemName.None;
        }
    }
}
