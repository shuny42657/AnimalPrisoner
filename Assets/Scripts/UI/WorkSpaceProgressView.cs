using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class WorkSpaceProgressView : MonoBehaviour
    {
        [SerializeField] GameObject gauge;
        [SerializeField] GaugeView gaugeView;
        [SerializeField] OverlayOffsetterWithCamera offsetter;
        bool offset;
        public void Show(bool isActive) { gauge.SetActive(isActive); }
        public void ModifyGauge(float rate)
        {
            Show(true);
            if (!offset)
            {
                offset = true;
                offsetter.SetUIPositionWithOffset();
            }
            gaugeView.ModifyGauge(rate);
        }
    }
}
