using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace GameLogic.WorkSpace
{
    public class BedWorkSpace : BaseWorkSpace
    {
        public override void InitializeWorkSpace()
        {
            base.InitializeWorkSpace();
            var bedAutomatable = (BedAutomatable)_automatable;

            bedAutomatable.onOperationFinish.AddListener((val) => _progressView.Show(false));
            bedAutomatable.OnProgressMade.AddListener((rate) => _progressView.ModifyGauge(rate));
            bedAutomatable.OnOperationInitiated.AddListener(() => _progressView.Show(true));
        }
        private void Start()
        {
            InitializeWorkSpace();
        }
    }
}
