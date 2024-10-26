using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class SubmissionWorkSpace : BaseWorkSpace
    {
        public override void InitializeWorkSpace()
        {
            base.InitializeWorkSpace();
            var objManagerPutAndTake = (ObjectiveMangerPutAndTake)_putAndTake;
            _putAndTake.OnPut.AddListener((item) => _putAndTake.Put(item));
        }

        private void Start()
        {
            InitializeWorkSpace();
        }
    }
}
