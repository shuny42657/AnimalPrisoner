using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Factory;
using GameLogic.GamePlayer;
using Photon.Pun;
using Sync;
using Cysharp.Threading.Tasks;
using UI;
using Photon.Realtime;
using GameLogic.Data;
using GameLogic.WorkSpace;
using Util;
using GameLogic.Map;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// Everything for the MainGame is set up here.
    /// </summary>
    public class MainGame : MonoBehaviourPunCallbacks
    {
        //Player
        PlayerManager _playerManager;
        [SerializeField] MainPlayerFactory playerFactory;

        MainGameInitializer gameInitializer;

        //Clock
        [SerializeField] UpdateClock _clock;

        [SerializeField] MapBuilder _mapBuilder;
        IJobAllocator jobAllocator = new MainJobAllocator();

        ObjectiveManager _objectiveManager;
        [SerializeField] LeveledObjectiveCreator _leveledObjectiveCreator;
        [SerializeField] ItemDataBase _itemDataBase;

        RoomParameterUpgrader _roomParamUpGrader;
        RoomParameter _roomParam;
        RoomParameterModifier _roomParamModifier;
        Pacer _roomParamPacer;
        Pacer _leveledObjCreatorPacer;
        Pacer _objectiveCreatorPacer;

        //WorkSpace Factory
        [SerializeField] MakerCrafterFactory _motherWorkSpaceFactory;
        SubmissionWorkSpaceControllerFactory _submissionWorkSpaceControllerFactory;
        BedWorkSpaceControllerFacotry _bedWorkSpaceControllerFactory;

        //Submission Space
        [SerializeField] WorkSpace.WorkSpace _submissionSpace;

        //Bed
        [SerializeField] WorkSpace.WorkSpace _bed;

        //Teleport System
        TeleporterReceiverInitializer _teleporterReceiverInitializer;
        [SerializeField] List<TeleportWorkSpace> _teleporters;
        [SerializeField] List<TeleportWorkSpace> _receivers;
        [SerializeField] List<PlayerCustomPropertyCallback> _receiverCustomPropCallbacks;

        [SerializeField] RoomPredicatePropertyCallback _gameoverPropertyCallback;
        [SerializeField] RoomIntegerPropertyCallback _decayLevelUpCallback;

        //View
        GameOverProcess _gameOverProcess;
        [SerializeField] GameOverView _gameOverView;
        [SerializeField] GaugeView _fuelGauge;
        [SerializeField] GaugeView _durabilityGauge;
        [SerializeField] GaugeView _electricityGauge;
        [SerializeField] ObjectiveViewerFactory _objectiveViewerFactory;

        //Controller
        [SerializeField] KeyDownController _e_keyDownController;
        [SerializeField] KeyDownController _f_keyDownController;

        // Start is called before the first frame update
        void Start()
        {
            _playerManager = playerFactory.GeneratePlayer(Vector3.zero);
            _motherWorkSpaceFactory.SetPlayer(_playerManager);
            _mapBuilder.SetPlayer(_playerManager);
            _playerManager.SetCanMove(true);
            _leveledObjectiveCreator.AddUpGradable(_playerManager);
            //_objectiveCreator.AddUpGradable(_playerManager);
            //プレイヤーの数が揃っていなかった場合は例外処理を飛ばしてマッチングシーンに戻る
            Debug.Log($"Player Count : {PhotonNetwork.PlayerList.Length}");

            //RoomParameterの初期化
            _roomParam = new(
                200f,
                200f,
                200f,
                5f, 5f, 5f
                );

            //RoomParameterUpgrader
            _roomParamUpGrader = new(
                _roomParam,
                new() { 1f, 2f, 3f, 4f, 5f },
                new() { 1f, 2f, 3f, 4f, 5f },
                new() { 1f, 2f, 3f, 4f, 5f });
            _decayLevelUpCallback.onModified.AddListener((val) => _roomParamUpGrader.UpGrade());

            //RoomParameterModifier
            _roomParamModifier = new(_itemDataBase, _roomParam);

            //Initialize RoomParameter Speed
            _roomParam.OnFuelModified.AddListener((rate) => _fuelGauge.ModifyGauge(rate));
            _roomParam.OnDurabilityModified.AddListener((rate) => _durabilityGauge.ModifyGauge(rate));
            _roomParam.OnElectricityModified.AddListener((rate) => _electricityGauge.ModifyGauge(rate));
            _roomParam.FuelComsumeSpeed = 5f;
            _roomParam.DuranilityCosumeSpeed = 5f;
            _roomParam.ElectricityConsumeSpeed = 5f;

            //ObjectiveManager
            _objectiveManager = new ObjectiveManager(_leveledObjectiveCreator);
            _objectiveManager.OnNewObjectiveGenerated.AddListener((objectiveData) => _objectiveViewerFactory.Generate(objectiveData));
            _objectiveManager.OnObjectiveAchieved.AddListener((objectiveData) => _objectiveViewerFactory.DeleteViewer(objectiveData));

            //Pacer
            ///RoomParamPacer
            _roomParamPacer = new(new(){ 10f,10f,10f,10f},true, false);
            _roomParamPacer.OnCheckpointReached.AddListener((val) => _roomParamUpGrader.IncrementLevel(val));
            _roomParamPacer.IsActive = true;

            ///LeveledObjCreatorPacer
            _leveledObjCreatorPacer = new(new(){10f,10f,10f,10f},false, false);
            _leveledObjCreatorPacer.OnCheckpointReached.AddListener((val) => _leveledObjectiveCreator.UpGrade());
            _leveledObjCreatorPacer.IsActive = true;

            ///ObjectiveCreatorPacer
            _objectiveCreatorPacer = new(new() { 20f},false, true);
            _objectiveCreatorPacer.OnCheckpointReached.AddListener((val) => _objectiveManager.AddNewObjective());
            _objectiveCreatorPacer.IsActive = true;

            //MapBuilder
            _mapBuilder.OnWorkSpaceGenerated.AddListener((workSpace) => _leveledObjectiveCreator.AddUpGradable(workSpace));

            //Allocate Jobs
            if (PhotonNetwork.IsMasterClient)
            {
                jobAllocator.AllocateJob();
            }

            //Register ITicks to IClock
            _clock.AddTick(_roomParamPacer);
            _clock.AddTick(_leveledObjCreatorPacer);
            _clock.AddTick(_objectiveCreatorPacer);
            _clock.AddTick(_roomParam);
            _clock.IsActive = true;

            //GameOver
            _gameOverProcess = new(_gameOverView, _roomParam, _leveledObjCreatorPacer, _objectiveCreatorPacer, _roomParamPacer);
            _roomParam.OnParamDead += () => SetGameOver();
            _gameoverPropertyCallback.onModified.AddListener(() => _gameOverProcess.RunGameOverProcess(_playerManager));
            _gameOverView.OnButtonClick.AddListener(() => PhotonNetwork.Disconnect());

            //Initialize Teleport System (Teleporters and Receivers)
            _teleporterReceiverInitializer = new(_playerManager, _teleporters, _receivers, _receiverCustomPropCallbacks, _e_keyDownController);
            _teleporterReceiverInitializer.InitializeGame();

            //SubmissionSpace
            _submissionWorkSpaceControllerFactory = new(_playerManager, _objectiveManager, _roomParamModifier,_e_keyDownController);
            _submissionSpace.SetWorkSpaceManager(_submissionWorkSpaceControllerFactory.GenerateWorkSpaceController(_submissionSpace));

            //Bed
            _bedWorkSpaceControllerFactory = new(_playerManager, _clock,_f_keyDownController);
            _bed.SetWorkSpaceManager(_bedWorkSpaceControllerFactory.GenerateWorkSpaceController(_bed));
            
        }

        public async UniTask SetGameOver()
        {
            await UniTask.Delay(10);
            PhotonNetwork.CurrentRoom.SetGameOver(true);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Disconnected");
            SceneLoadManager.MoveToTitle();
        }
    }
}
