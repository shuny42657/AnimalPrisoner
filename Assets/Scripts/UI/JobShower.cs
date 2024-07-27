using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Util;
using UnityEngine.UI;

namespace UI
{
    public class JobShower : MonoBehaviour
    {
        [SerializeField] SerializeInterface<IShowHide> showHide;
        [SerializeField] SerializeInterface<IAnimationPlayer> animationPlayer;
        [SerializeField] Image[] images;

        public void ShowJob(List<Sprite> sprites)
        {
            showHide.Value.Show(true);
            for(int i = 0;i < images.Length; i++)
            {
                images[i].sprite = sprites[i];
            }

            StartCoroutine(ShowJobProcess());
        }

        IEnumerator ShowJobProcess()
        {
            animationPlayer.Value.PlayAnimation();
            yield return new WaitForSeconds(5f);
            showHide.Value.Show(false);
        }
    }
}
