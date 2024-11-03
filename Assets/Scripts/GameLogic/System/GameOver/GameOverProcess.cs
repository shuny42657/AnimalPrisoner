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
        RoomParameter _roomParam;
        Pacer _roomParamPacer;
        Pacer _leveledObjCreatorPacer;
        Pacer _objectiveCreatorPacer;

        public GameOverProcess(
            IPlayer player,
            IViewAppear gameOverView,
            RoomParameter roomParam,
            Pacer leveldObjCreatorPacer,
            Pacer objectiveCreatorPacer,
            Pacer roomParamPacer
            )
        {
            _gameOverView = gameOverView;
            _roomParam = roomParam;
            _roomParamPacer = roomParamPacer;
            _leveledObjCreatorPacer = leveldObjCreatorPacer;
            _objectiveCreatorPacer = objectiveCreatorPacer;
        }
        public async UniTask RunGameOverProcess()
        {
            Debug.Log("Game Over Processs");
             _player.SetCanMove(false);
            _roomParam.IsActive = false;
            _roomParamPacer.IsActive = false;
            _leveledObjCreatorPacer.IsActive = false;
            _objectiveCreatorPacer.IsActive = false;
            await _gameOverView.Appear();
        }
    }
}
