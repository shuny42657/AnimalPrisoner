using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Util
{
    public class KeyUpController : MonoBehaviour
    {
        [SerializeField] KeyCode key;
        public UnityEvent OnKeyReleased;

        private void Update()
        {
            if (Input.GetKeyUp(key))
            {
                OnKeyReleased.Invoke();
            }
        }
    }
}

