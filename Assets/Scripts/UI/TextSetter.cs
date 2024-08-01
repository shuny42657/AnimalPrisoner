using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class TextSetter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI text;

        public void SetText(string text)
        {
            this.text.text = text;
        }
    }
}
