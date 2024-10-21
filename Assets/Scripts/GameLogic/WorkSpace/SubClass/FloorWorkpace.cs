using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class FloorWorkpace : BaseWorkSpace
    {
        private void Start()
        {
            InitializeWorkSpace();
        }
        public override void InitializeWorkSpace()
        {
            base.InitializeWorkSpace();
            _putAndTake.OnPut.AddListener((item) => _grabbableVisualizer.Show(item));
            _putAndTake.OnTake.AddListener(() => _grabbableVisualizer.Delete());
        }
    }
}
