using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class ButtonPresenter : MonoBehaviour
    {
        [SerializeField] Button button;
        [SerializeField] List<UnityEvent> unityEvents;
        private void Awake()
        {
            button.onClick.AddListener(() => { foreach (var unityEvent in unityEvents) unityEvent.Invoke(); });
        }
    }
}
