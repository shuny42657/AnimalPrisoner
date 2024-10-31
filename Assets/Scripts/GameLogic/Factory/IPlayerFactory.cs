using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using GameLogic.WorkSpace;

namespace GameLogic.GamePlayer
{
    /// <summary>
    /// Playerに実装させたい処理
    /// </summary>
    public interface IPlayer
    {
        public void Work(IWork work);
        public void StartOperation(IAutomatable automatable);
        public void SetCanMove(bool isActive);
        public void MoveRight();
        public void MoveLeft();
        public void MoveUp();
        public void MoveDown();
        public void PutOrTake(IPutAndTake putAndTake);
        public void HealEnergy();
    }
}
namespace GameLogic.Factory
{
    public interface IPlayerFactory
    {
        public PlayerManager GeneratePlayer(Vector3 position);
    }
}
