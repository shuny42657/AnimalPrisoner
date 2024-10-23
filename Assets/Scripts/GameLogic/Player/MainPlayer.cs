using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using GameLogic.GamePlayer;
using GameLogic.GameSystem;
using GameLogic.Map;
using UI;
using Sync;
using Util;

namespace GameLogic.Factory
{
    /// <summary>
    /// PlayerPrefabにつけて、ゲームで動くPlayerを生成する
    /// </summary>
    public class MainPlayer : MonoBehaviour,IPlayerFactory
    {
        [SerializeField] GameObject _playerPrefab;
        [SerializeField] IPlayerStatus _playerStatus;
        [SerializeField] IJobStatus _jobStatus;
        [SerializeField] IOperatableHandler _playerOperatableHandler;
        [SerializeField] IOperatableCallback _operatableCallback;
        [SerializeField] IUpGradable _playerSpeedUpGradable;
        [SerializeField] IMovable _move;
        [SerializeField] IGrabbableVisualizer _visualizer;

        KeyHoldController _rightKeyHoldController;
        KeyHoldController _leftKeyHoldController;
        KeyHoldController _upKeyHoldController;
        KeyHoldController _downKeyHoldController;
        KeyHoldController _qKeyHoldController;
        KeyDownController _eKeyDownController;
        KeyDownController _fKeyDownController;

        [SerializeField] PlayerCustomPropertyCallback _playerCustomPropertyCallback;
        [SerializeField] MapBuilder _mapBuilder;
        [SerializeField] JobDisplay _jobDisplay;

        [SerializeField] GaugeView _playerStatusGaugeView;

        [SerializeField] ObjectiveCreator _objectiveCreator;

        [SerializeField] BedAutomatable _bedAutomatable;

        PlayerManager _playerManager; public PlayerManager PlayerManager { get { return _playerManager; } }

        public void InitiateOperation(PlayerManager playerManager)
        {
            playerManager.SetCanMove(false);
        }

        public void FinishOperation(PlayerManager playerManager)
        {
            playerManager.SetCanMove(true);
            playerManager.PlayerStatus.Energy = playerManager.PlayerStatus.MaxEnergy;
        }

        public IPlayer GeneratePlayer(Vector3 position)
        {
            GameObject newPlayer = Instantiate(_playerPrefab, position, Quaternion.identity);

            _playerStatus = newPlayer.GetComponent<IPlayerStatus>();
            _jobStatus = newPlayer.GetComponent<IJobStatus>();
            _playerOperatableHandler = newPlayer.GetComponent<IOperatableHandler>();
            _operatableCallback = newPlayer.GetComponent<IOperatableCallback>();
            _playerSpeedUpGradable = newPlayer.GetComponent<IUpGradable>();
            _move = newPlayer.GetComponent<IMovable>();
            _visualizer = newPlayer.GetComponent<IGrabbableVisualizer>();

            _upKeyHoldController = newPlayer.transform.GetChild(1).GetComponent<KeyHoldController>();
            _leftKeyHoldController = newPlayer.transform.GetChild(2).GetComponent<KeyHoldController>();
            _downKeyHoldController = newPlayer.transform.GetChild(3).GetComponent<KeyHoldController>();
            _rightKeyHoldController = newPlayer.transform.GetChild(4).GetComponent<KeyHoldController>();
            _qKeyHoldController = newPlayer.transform.GetChild(5).GetComponent<KeyHoldController>();
            _eKeyDownController = newPlayer.transform.GetChild(6).GetComponent<KeyDownController>();
            _fKeyDownController = newPlayer.transform.GetChild(7).GetComponent<KeyDownController>();

            var playerManager = new PlayerManager(
                _playerOperatableHandler,
                _playerStatus,
                _jobStatus,
                _move,
                _playerSpeedUpGradable
                );

            _rightKeyHoldController.OnKeyHold.AddListener(() => playerManager.MoveRight());
            _leftKeyHoldController.OnKeyHold.AddListener(() => playerManager.MoveLeft());
            _downKeyHoldController.OnKeyHold.AddListener(() => playerManager.MoveDown());
            _upKeyHoldController.OnKeyHold.AddListener(() => playerManager.MoveUp());
            _qKeyHoldController.OnKeyHold.AddListener(() => playerManager.Work());
            _eKeyDownController.OnKeyPressed.AddListener(() => playerManager.PutOrTake());
            _fKeyDownController.OnKeyPressed.AddListener(() => playerManager.StartOperation());

            _playerCustomPropertyCallback.onComplete.AddListener(() => _jobStatus.SetJobs());
            _jobStatus.OnJobSet.AddListener((i_jobStatus) => _mapBuilder.BuildWorkSpaces(i_jobStatus));
            _jobStatus.OnJobSet.AddListener((i_jobStatus) => _jobDisplay.DisplayJob(i_jobStatus));

            _playerStatus.OnEnergyModified.AddListener((rate) => _playerStatusGaugeView.ModifyGauge(rate));

            _bedAutomatable.onOperationFinish.AddListener((val) => FinishOperation(playerManager));
            _bedAutomatable.OnOperationInitiated.AddListener(() => InitiateOperation(playerManager));

            _operatableCallback.OnPut.AddListener((itemName) => _visualizer.Delete());
            _operatableCallback.OnTake.AddListener((itemName) => _visualizer.Show(itemName));
            return playerManager;
        }
    }

}
