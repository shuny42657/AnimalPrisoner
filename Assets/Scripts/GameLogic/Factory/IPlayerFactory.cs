using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;

namespace GameLogic.GamePlayer
{
    /// <summary>
    /// Playerに実装させたい処理
    /// </summary>
    public interface IPlayer
    {
        public void Work();
        public void StartOperation();
        public void SetCanMove(bool isActive);
        public void MoveRight();
        public void MoveLeft();
        public void MoveUp();
        public void MoveDown();
        public void PutOrTake();
    }
}
namespace GameLogic.Factory
{
    public interface IPlayerFactory
    {
        public IPlayer GeneratePlayer(Vector3 position);
    }
}
