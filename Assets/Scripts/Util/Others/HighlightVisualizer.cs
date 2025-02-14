using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class HighlightVisualizer : MonoBehaviour, IHilightVisualizer
    {
        [SerializeField] GameObject baseObject;
        [SerializeField] GameObject hilightObject;
        public void Hilight(bool isActive)
        {
            hilightObject.SetActive(isActive);
            if(baseObject != null)
                baseObject.SetActive(!isActive);
        }
    }
}
