using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public interface IGaugeView
    {
        public void ModifyGauge(float rate);
    }
}
