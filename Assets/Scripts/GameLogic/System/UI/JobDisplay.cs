using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using GameLogic.GamePlayer;
using GameLogic.Data;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// Play an animation that tells a player what kind of jobs he has.
    /// Usually used at the beginning of a new game.
    /// </summary>
    public class JobDisplay : MonoBehaviour
    {
        [SerializeField] JobDataBase jobDatabase;
        [SerializeField] SerializeInterface<IAnimationPlayer> animationPlayer;
        [SerializeField] ShowHide showHide;
        [SerializeField] SpritesLister spritesLister;
        [SerializeField] TextLister textLister;

        public void DisplayJob(IJobStatus jobStatus)
        {
            List<Sprite> sprites = new() ;
            List<string> jobNames = new();
            foreach(var j in jobStatus.GetAllJobs())
            {
                sprites.Add(jobDatabase.GetData(j).SourceImage);
                jobNames.Add(j.ToString());
            }
            spritesLister.SetSprites(sprites);
            textLister.SetTexts(jobNames);
            StartCoroutine(ShowJobProcess());
        }

        IEnumerator ShowJobProcess()
        {
            showHide.Show(true);
            animationPlayer.Value.PlayAnimation();
            yield return new WaitForSeconds(5f);
            showHide.Show(false);
        }
    }
}
