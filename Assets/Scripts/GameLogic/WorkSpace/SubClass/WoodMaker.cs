using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class WoodMaker : BaseWorkSpace
    {
        public override void InitializeWorkSpace()
        {
            base.InitializeWorkSpace();
            _putAndTake.OnPut.AddListener((item) => _grabbableVisualizer.Show(item));
            _putAndTake.OnTake.AddListener(() => _grabbableVisualizer.Delete());

            var makerWork = (MakerWork)_work;
            makerWork.OnWorkStart.AddListener(() => _progressView.Show(true));
            //makerWork.OnWorkFinish.AddListener((item) => _set.Set(item));
            //makerWork.OnWorkFinish.AddListener((item) => _progressView.Show(false));
            //makerWork.OnWorkFinish.AddListener((item) => makerWork.ClearSpace(false));
            makerWork.OnProgressMade.AddListener((rate) => _progressView.ModifyGauge(rate));

            _putAndTake.OnTake.AddListener(() => makerWork.ClearSpace(true));
        }
    }
}
