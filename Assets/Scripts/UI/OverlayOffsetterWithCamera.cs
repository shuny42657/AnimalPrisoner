using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayOffsetterWithCamera : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    [SerializeField] Transform targetTransform;
    [SerializeField] Vector2 offset;

    public void SetUIPositionWithOffset()
    {
        rect.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTransform.position) + offset;
    }
}
