using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class ReceiverTextView : MonoBehaviour,ITextView<int>
    {
        [SerializeField] TextMeshProUGUI text;

        public void ShowText(int val)
        {
            text.text = $"From Player{val}";
        }
    }
}
