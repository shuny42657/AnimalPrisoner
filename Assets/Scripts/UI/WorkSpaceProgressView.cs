using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(IGaugeView))]
    [RequireComponent(typeof(IShowHide))]
    public class WorkSpaceProgressView : MonoBehaviour,IShowHide,IGaugeView
    {
        IGaugeView gaugeView;
        IShowHide showHide;
        [SerializeField] OverlayOffsetterWithCamera offsetter;
        bool offset;

        private void Awake()
        {
            gaugeView = GetComponent<GaugeView>();
            showHide = GetComponent<ShowHide>();
        }

        //public void Show(bool isActive) { gauge.SetActive(isActive); }
        public void ModifyGauge(float rate)
        {
            //Debug.Log($"gauge view : {gaugeView != null}");
            Debug.Log($" rate : {rate}");
            if (!offset)
            {
                offset = true;
                offsetter.SetUIPositionWithOffset();
            }
            gaugeView.ModifyGauge(rate);
        }

        public void Show(bool isActive)
        {
            showHide.Show(isActive);
        }
    }
}
