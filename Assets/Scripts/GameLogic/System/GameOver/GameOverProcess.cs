using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Util;
using UI;
using GameLogic.GamePlayer;

namespace GameLogic.GameSystem
{
    public class GameOverProcess : MonoBehaviour
    {
        [SerializeField] SerializeInterface<IViewAppear> _gameOverView;
        [SerializeField] RoomParameter _roomParam;
        [SerializeField] Pacer _roomParamPacer;
        [SerializeField] Pacer _leveledObjCreatorPacer;
        [SerializeField] Pacer _objectiveCreatorPacer;
        [SerializeField] RoomParameterModifier _roomParamModifier;

        public async UniTask RunGameOverProcess(IPlayer playerManager)
        {
            Debug.Log("Game Over Processs");
             playerManager.SetCanMove(false);
            _roomParam.IsActive = false;
            _roomParamPacer.IsActive = false;
            _leveledObjCreatorPacer.IsActive = false;
            _objectiveCreatorPacer.IsActive = false;
            await _gameOverView.Value.Appear();
        }
    }
}
