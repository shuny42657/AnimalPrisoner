using System.Collections;
using System.Collections.Generic;
using GameLogic.GamePlayer;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class MakerWork : BaseWork<ItemName>
    {
        //float progress;
        //[SerializeField] float maxProgress;
        //[SerializeField] UnityEvent<ItemName> onWorkFinish; public UnityEvent<ItemName> OnWorkFinish { get { return onWorkFinish; } }

        //[SerializeField] UnityEvent<float> onProgressMade; public UnityEvent<float> OnProgressMade { get { return onProgressMade; } }

        //float workSpeed = 1f;
        //public float WorkSpeed { get { return workSpeed; } set { workSpeed = value; } }

        //[SerializeField] ItemName itemName;

        /// <summary>
        /// Whether a generated item was taken by the player.
        /// As long as this is false, a new work cannot be started.
        /// </summary>
        /// 
        bool isSpaceCleared = true;
        public void ClearSpace(bool isActive) { isSpaceCleared = isActive; }

        public override void Work(IPlayerStatus playerStatus)
        {
            if (isSpaceCleared)
            {
                /*if (playerStatus.Energy > 0)
                {
                    progress += Time.deltaTime * workSpeed;
                    playerStatus.Energy -= Time.deltaTime * workSpeed;
                    OnProgressMade.Invoke(progress / maxProgress);
                    //Debug.Log($"Energy {progress}");

                    if (progress > maxProgress)
                    {
                        progress = 0;
                        OnWorkFinish.Invoke(item);
                    }
                }
                else
                {
                    Debug.Log("no work");
                }*/
                base.Work(playerStatus);
            }
        }
    }
}
