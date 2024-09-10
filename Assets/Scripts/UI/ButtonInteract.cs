using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Written by Shinnosuke
    /// </summary>
    public class ButtonInteract: MonoBehaviour, IShowHide
    {
        [SerializeField] Button button;
        public void Show(bool isActive)
        {
            button.interactable = isActive;
        }
    }
}
