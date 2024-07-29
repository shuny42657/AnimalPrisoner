using System.Collections;
using System.Collections.Generic;
using GameLogic.GamePlayer;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class MakerWork : MonoBehaviour,IWork
    {
        float progress;
        [SerializeField] float maxProgress;
        [SerializeField] UnityEvent<ItemName> onWorkFinish; public UnityEvent<ItemName> OnWorkFinish { get { return onWorkFinish; } }

        [SerializeField] UnityEvent<float> onProgressMade; public UnityEvent<float> OnProgressMade { get { return onProgressMade; } }

        float workSpeed = 1f;
        public float WorkSpeed { get { return workSpeed; } set { workSpeed = value; } }

        [SerializeField] ItemName itemName;

        public void Work(IPlayerStatus playerStatus)
        {
            if(playerStatus.Energy > 0)
            {
                progress += Time.deltaTime * workSpeed;
                playerStatus.Energy -= Time.deltaTime * workSpeed;
                onProgressMade.Invoke(progress / maxProgress);
                //Debug.Log($"Energy {progress}");

                if(progress > maxProgress)
                {
                    progress = 0;
                    onWorkFinish.Invoke(itemName);
                }
            }
            else
            {
                Debug.Log("no work");
            }
        }
    }
}
