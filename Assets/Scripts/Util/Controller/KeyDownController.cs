using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Util
{
    public class KeyDownController : MonoBehaviour
    {
        [SerializeField] KeyCode key;
        public UnityEvent OnKeyPressed;

        private void Update()
        {
            if (Input.GetKeyDown(key))
            {
                OnKeyPressed.Invoke();
            }
        }
    }
}

