using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GaugeView : MonoBehaviour,IGaugeView
    {
        [SerializeField] Image gauge;

        public void ModifyGauge(float rate)
        {
            gauge.fillAmount = rate;
        }
    }
}
