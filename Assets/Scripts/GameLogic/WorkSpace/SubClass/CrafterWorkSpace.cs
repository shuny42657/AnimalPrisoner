using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class CrafterWorkSpace : BaseWorkSpace
    {
        public override void InitializeWorkSpace()
        {
            base.InitializeWorkSpace();

            var crafterAutomatable = (CrafterAutomatable)_automatable;
            var crafterPutAndTake = (CrafterPutAndTake)_putAndTake;
            //_putAndTake.OnPut.AddListener((item) => crafterAutomatable.SetItemToCraft(item));
            _putAndTake.OnTake.AddListener(() => _grabbableVisualizer.Delete());
            _set.OnSet.AddListener((item) => _grabbableVisualizer.Show(item));

            crafterAutomatable.OnOperationInitiated.AddListener(() => crafterPutAndTake.ResetSetQuantity());
            crafterAutomatable.OnOperationInitiated.AddListener(() => _progressView.Show(true));
            crafterAutomatable.OnProgressMade.AddListener((rate) => _progressView.ModifyGauge(rate));
            //crafterAutomatable.onOperationFinish.AddListener((item) => crafterPutAndTake.Set(item));
            //crafterAutomatable.onOperationFinish.AddListener((item) => _progressView.Show(false));
        }
    }
}