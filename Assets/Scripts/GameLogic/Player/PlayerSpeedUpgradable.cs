using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

namespace GameLogic.GamePlayer
{
    public class PlayerSpeedUpgradable : MonoBehaviour,IUpGradable
    {
        [SerializeField] SerializeInterface<IMovable> movable;
        int level = 0;
        public int Level { get { return level; } }

        [SerializeField] UpGraderName upgraderName;
        public UpGraderName UpGraderName { get { return upgraderName; } }

        [SerializeField] List<float> speeds;
        public void UpGrade()
        {
            level++;
            movable.Value.Speed = speeds[level];
        }
    }
}
