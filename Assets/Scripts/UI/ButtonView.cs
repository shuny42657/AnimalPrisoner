using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Written by Shinnosuke
    /// </summary>
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] UnityEvent unityEvent;
        private void Awake()
        {
            button.onClick.AddListener(() => unityEvent.Invoke());
        }
    }
}
