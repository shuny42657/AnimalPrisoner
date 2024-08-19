using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class TextLister : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI[] texts;
        public void SetTexts(List<string> texts)
        {
            for(int i = 0; i < this.texts.Length; i++)
            {
                this.texts[i].text = texts[i];
            }
        }
    }
}
