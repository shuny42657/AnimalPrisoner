using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace GameLogic.WorkSpace
{
    public class TeleporterWorkSpace : BaseWorkSpace
    {
        [SerializeField] TeleporterTextView _teleporterTextView;
        public override void InitializeWorkSpace()
        {
            base.InitializeWorkSpace();
            _putAndTake.OnPut.AddListener((item) => _putAndTake.Put(item));

            var teleporterPutAndTake = (TeleporterPutAndTake)_putAndTake;
            teleporterPutAndTake.OnReceiverIDSet.AddListener((playerNum) => _teleporterTextView.ShowText(playerNum));
        }
    }
}
