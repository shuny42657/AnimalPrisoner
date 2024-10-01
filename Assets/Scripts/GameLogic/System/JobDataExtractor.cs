using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using GameLogic.Data;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public class JobDataExtractor : MonoBehaviour
    {
        [SerializeField] JobDataBase jobDataBase;

        [SerializeField] UnityEvent<List<Sprite>> JobDataSpriteCallback;
        public void ExtractJobSprites(IJobStatus jobStats)
        {
            List<Sprite> sprites = new();
            foreach(var j in jobStats.GetAllJobs())
            {
                sprites.Add(jobDataBase.GetData(j).SourceImage);
            }
            Debug.Log("Job Extracted");
            JobDataSpriteCallback.Invoke(sprites);
        }
    }
}
