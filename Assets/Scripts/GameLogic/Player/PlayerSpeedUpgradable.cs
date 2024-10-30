using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;

namespace GameLogic.GamePlayer
{
    public class PlayerSpeedUpgradable : IUpGradable
    {
        IMovable _movable;
        int level = 0;
        public int Level { get { return level; } }

        const UpGraderName upgraderName = UpGraderName.PlayerSpeed;
        public UpGraderName UpGraderName { get { return upgraderName; } }

        List<float> _speeds = new();

        public PlayerSpeedUpgradable(IMovable movable,List<float> speeds)
        {
            _movable = movable;
            _speeds = speeds;
        }

        public void UpGrade()
        {
            level++;
            _movable.Speed = _speeds[level];
        }
    }
}
