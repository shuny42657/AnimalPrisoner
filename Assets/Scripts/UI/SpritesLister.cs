using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Util;
using UnityEngine.UI;

namespace UI
{
    //Set a series of sprites to images with a single call of a method.
    public class SpritesLister : MonoBehaviour
    {
        [SerializeField] SerializeInterface<IShowHide> showHide;
        [SerializeField] SerializeInterface<IAnimationPlayer> animationPlayer;
        [SerializeField] Image[] images;

        public void SetSprites(List<Sprite> sprites)
        {
            for(int i = 0;i < images.Length; i++)
            {
                images[i].sprite = sprites[i];
            }
        }
    }
}
