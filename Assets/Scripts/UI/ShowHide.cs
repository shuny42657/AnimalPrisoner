using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ShowHide : MonoBehaviour,IShowHide
    {
        [SerializeField] GameObject obj;
        public void Show(bool isActive)
        {
            obj.SetActive(isActive);
        }
    }
}
