using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sync;
using UI;

namespace GameLogic.WorkSpace
{
    public class ReceiverWorkSpace : BaseWorkSpace
    {
        PlayerCustomPropertyCallback _playerCustomPropertyCallback;
        [SerializeField] ReceiverTextView _receiverTextView;

        public override void InitializeWorkSpace()
        {
            base.InitializeWorkSpace();
            _playerCustomPropertyCallback = GetComponent<PlayerCustomPropertyCallback>();

            var receiverPutAndTake = (ReceierPutAndTake)_putAndTake;

            _putAndTake.OnPut.AddListener((item) => _grabbableVisualizer.Show(item));
            _putAndTake.OnTake.AddListener(() => _grabbableVisualizer.Delete());

            receiverPutAndTake.OnSenderIdSet.AddListener((index) => _receiverTextView.ShowText(index));

            _playerCustomPropertyCallback.onComplete.AddListener(receiverPutAndTake.SetReceivedItem);
            /*if(PlayerTrigger == null)
            {
                Debug.Log("player trigger null");
            }
            else
            {
                Debug.Log("player trigger not null");
            }*/
        }

        private void Start()
        {
            InitializeWorkSpace();
        }
    }
}
