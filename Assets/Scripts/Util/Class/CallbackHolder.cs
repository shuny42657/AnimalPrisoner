using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Util
{
    public class CallbackHolder : MonoBehaviour
    {
        public UnityEvent OnVoidFire = new();
        public UnityEvent<int> OnIntFire = new();
        public UnityEvent<float> OnFloatFIre = new();
        public UnityEvent<Vector3> OnVector3Fire = new();
        public UnityEvent<bool> OnBoolFire = new();
        public UnityEvent<string> OnStrFire = new();
    }
}
