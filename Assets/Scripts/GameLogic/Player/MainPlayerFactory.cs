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
    public class MainPlayerFactory : MonoBehaviour,IPlayerFactory
    {
        [SerializeField] GameObject _playerPrefab;
        IPlayerStatus _playerStatus;
        IJobStatus _jobStatus;
        IOperatableHandler _playerOperatableHandler;
        IOperatableCallback _operatableCallback;
        IUpGradable _playerSpeedUpGradable;
        IMovable _move;
        IGrabbableVisualizer _visualizer;

        KeyHoldController _rightKeyHoldController;
        KeyHoldController _leftKeyHoldController;
        KeyHoldController _upKeyHoldController;
        KeyHoldController _downKeyHoldController;

        KeyDownController _rightKeyDownController;
        KeyDownController _leftKeyDownController;
        KeyDownController _upKeyDownController;
        KeyDownController _downKeyDownController;

        KeyUpController _rightKeyUpController;
        KeyUpController _leftKeyUpController;
        KeyUpController _upKeyUpController;
        KeyUpController _downKeyUpContoller;

        Animator _animator;

        [SerializeField] PlayerCustomPropertyCallback _playerCustomPropertyCallback;
        [SerializeField] MapBuilder _mapBuilder;
        [SerializeField] JobDisplay _jobDisplay;

        [SerializeField] GaugeView _playerStatusGaugeView;

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

        public PlayerManager GeneratePlayer(Vector3 position)
        {
            GameObject newPlayer = Instantiate(_playerPrefab, position, Quaternion.identity);

            _playerStatus = newPlayer.GetComponent<IPlayerStatus>();
            _jobStatus = newPlayer.GetComponent<IJobStatus>();
            _playerOperatableHandler = newPlayer.GetComponent<IOperatableHandler>();
            _operatableCallback = newPlayer.GetComponent<IOperatableCallback>();
            _move = newPlayer.GetComponent<IMovable>();
            _playerSpeedUpGradable = new PlayerSpeedUpgradable(_move, new() { 1f, 1.5f, 2f, 2.5f, 3f });
            _visualizer = newPlayer.GetComponent<IGrabbableVisualizer>();
            _animator = newPlayer.transform.GetChild(8).GetComponent<Animator>();
            _upKeyHoldController = newPlayer.transform.GetChild(1).GetComponent<KeyHoldController>();
            _leftKeyHoldController = newPlayer.transform.GetChild(2).GetComponent<KeyHoldController>();
            _downKeyHoldController = newPlayer.transform.GetChild(3).GetComponent<KeyHoldController>();
            _rightKeyHoldController = newPlayer.transform.GetChild(4).GetComponent<KeyHoldController>();

            _upKeyDownController = newPlayer.transform.GetChild(1).GetComponent<KeyDownController>();
            _leftKeyDownController = newPlayer.transform.GetChild(2).GetComponent<KeyDownController>();
            _downKeyDownController = newPlayer.transform.GetChild(3).GetComponent<KeyDownController>();
            _rightKeyDownController = newPlayer.transform.GetChild(4).GetComponent<KeyDownController>();

            _upKeyUpController = newPlayer.transform.GetChild(1).GetComponent<KeyUpController>();
            _leftKeyUpController = newPlayer.transform.GetChild(2).GetComponent<KeyUpController>();
            _downKeyUpContoller = newPlayer.transform.GetChild(3).GetComponent<KeyUpController>();
            _rightKeyUpController = newPlayer.transform.GetChild(4).GetComponent<KeyUpController>();

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
            //_qKeyHoldController.OnKeyHold.AddListener(() => playerManager.Work());
            //_eKeyDownController.OnKeyPressed.AddListener(() => playerManager.PutOrTake());
            //_fKeyDownController.OnKeyPressed.AddListener(() => playerManager.StartOperation());
            _rightKeyDownController.OnKeyPressed.AddListener(() => _animator.SetInteger("Direction", 2));
            _leftKeyDownController.OnKeyPressed.AddListener(() => _animator.SetInteger("Direction", 1));
            _downKeyDownController.OnKeyPressed.AddListener(() => _animator.SetInteger("Direction", 0));
            _upKeyDownController.OnKeyPressed.AddListener(() => _animator.SetInteger("Direction", 3));

            _rightKeyUpController.OnKeyReleased.AddListener(() => _animator.SetInteger("Direction", -1));
            _leftKeyUpController.OnKeyReleased.AddListener(() => _animator.SetInteger("Direction", -1));
            _upKeyUpController.OnKeyReleased.AddListener(() => _animator.SetInteger("Direction", -1));
            _downKeyUpContoller.OnKeyReleased.AddListener(() => _animator.SetInteger("Direction", -1));

            _playerCustomPropertyCallback.onComplete.AddListener(() => _jobStatus.SetJobs());
            _jobStatus.OnJobSet.AddListener((i_jobStatus) => _mapBuilder.BuildWorkSpaces(i_jobStatus));
            _jobStatus.OnJobSet.AddListener((i_jobStatus) => _jobDisplay.DisplayJob(i_jobStatus));

            _playerStatus.OnEnergyModified.AddListener((rate) => _playerStatusGaugeView.ModifyGauge(rate));

            _operatableCallback.OnPut.AddListener((itemName) => _visualizer.Delete());
            _operatableCallback.OnTake.AddListener((itemName) => _visualizer.Show(itemName));
            return playerManager;
        }
    }
}
