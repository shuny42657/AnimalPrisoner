using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class IntSetter : MonoBehaviour
    {
        [SerializeField] int num;

        public void SetInt(int num)
        {
            this.num = num;
        }
    }
}
