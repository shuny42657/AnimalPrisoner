using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Util;
using UI;
using GameLogic.GamePlayer;

namespace GameLogic.GameSystem
{
    public class GameOverProcess
    {
        IPlayer _player;
        IViewAppear _gameOverView;

        public GameOverProcess(
            IPlayer player,
            IViewAppear gameOverView
            )
        {
            _player = player;
            _gameOverView = gameOverView;
        }
        public async UniTask RunGameOverProcess()
        {
            Debug.Log("Game Over Processs");
             _player.SetCanMove(false);
            await _gameOverView.Appear();
        }
    }
}
