using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ImageSetter : MonoBehaviour
    {
        [SerializeField] Image source;

        public void SetImage(Sprite sprite)
        {
            source.sprite = sprite;
        }
    }
}
