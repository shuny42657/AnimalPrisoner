using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class IntTextView : MonoBehaviour ,ITextView<int>
    {
        [SerializeField] TextMeshProUGUI text;
        public void ShowText(int val)
        {
            text.text = val.ToString();
        }
    }
}
