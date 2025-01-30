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

        //Clock
        [SerializeField] UpdateClock _clock;

        //Map Builder
        [SerializeField] MapBuilder _mapBuilder;

        //Job Allocation
        IJobAllocator jobAllocator = new MainJobAllocator();

        //Team Initialization
        ITeamInitlaizer _teamInitializer;
        ITeamable _teamSetter = new TeamSetter();

        //Objective 
        ObjectiveManager _objectiveManagerA;
        ObjectiveManager _objectiveManagerB;
        SimpleObjectiveManager _simpleObjManagerA;
        SimpleObjectiveManager _simpleObjManagerB;
        ObjectiveManager _objectiveManagerI;
        [SerializeField] ObjectiveInitializer _objectiveInitializer;
        [SerializeField] LeveledObjectiveCreator _leveledObjectiveCreator;
        [SerializeField] ItemDataBase _itemDataBase;

        IProgressController _progressController;

        IObjectiveIconView _objectiveIconViewA;
        IObjectiveIconView _objectiveIconViewB;

        //RoomParam
        RoomParameterUpgrader _roomParamUpGrader;
        RoomParameter _roomParam;
        RoomParameterModifier _roomParamModifier;

        //Pacer (ITick)
        Pacer _roomParamPacer;
        Pacer _leveledObjCreatorPacer;
        Pacer _objectiveCreatorPacer;

        //WorkSpace Factory
        [SerializeField] MakerCrafterFactory _motherWorkSpaceFactory;
        SubmissionWorkSpaceManagerFactory _submissionWorkSpaceControllerFactory;
        BedWorkSpaceManagerFacotry _bedWorkSpaceControllerFactory;

        //Submission Space
        [SerializeField] WorkSpace.WorkSpace _submissionSpace;

        //Bed
        [SerializeField] WorkSpace.WorkSpace _bed;

        //Teleport System
        TeleporterReceiverInitializer _teleporterReceiverInitializer;
        [SerializeField] List<TeleportWorkSpace> _teleporters;
        [SerializeField] List<TeleportWorkSpace> _receivers;
        [SerializeField] List<PlayerCustomPropertyCallback> _receiverCustomPropCallbacks;

        //Signal System
        SignalInitializer _signalInitializer;
        [SerializeField] List<PlayerCustomPropertyCallback> _signalCustomPropCallbacks;
        [SerializeField] List<SignalViewerFactory> _signalReceivers;
        // Added by Shinnosuke (2024/12/13)

        //Player Information View
        PlayerInfoInitializer _playerInfoInitializer;
        [SerializeField] List<PlayerInfoViewer> _viewers;
        // Added by Shinnosuke (2024/12/17)

        //Synchronization
        [SerializeField] RoomPredicatePropertyCallback _gameoverPropertyCallback;
        [SerializeField] RoomIntegerPropertyCallback _decayLevelUpCallback;
        [SerializeField] RoomIntegerPropertyCallback _teamAlphaProgressCallback;
        [SerializeField] RoomIntegerPropertyCallback _teamBetaProgressCallback;
        [SerializeField] RoomObjectivePropertyCallback _objectivePropertyCallback;

        //View
        GameOverProcess _gameOverProcess;
        [SerializeField] GameOverView _gameOverView;
        [SerializeField] GaugeView _fuelGauge;
        [SerializeField] GaugeView _durabilityGauge;
        [SerializeField] GaugeView _electricityGauge;
        [SerializeField] ObjectiveViewerFactory _objectiveViewerFactory;

        // Added by Shinnosuke (2025/1/3)
        [SerializeField] GaugeView _objectiveGaugeA;
        [SerializeField] GaugeView _objectiveGaugeB;
        [SerializeField] GaugeView _objectiveGaugeI;
        ObjectiveProgressViewer _objectiveProgressViewerA;
        ObjectiveProgressViewer _objectiveProgressViewerB;
        ObjectiveProgressViewer _objectiveProgressViewerI;

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
            _teamInitializer = new TeamInitializer(_teamSetter);
            _teamInitializer.InitializeTeam();
            //_leveledObjectiveCreator.AddUpGradable(_playerManager);

            //RoomParameter
            _roomParam = new(
                200f,
                200f,
                200f,
                5f, 5f, 5f
                );
            _roomParam.IsActive = true;

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
            _objectiveManagerA = new (); //new ObjectiveManager(_objectiveInitializer, 3, TeamName.Alpha);
            _objectiveManagerB = new(); //ObjectiveManager(_objectiveInitializer, 3, Team.Alpha);
            _objectiveManagerA.Init(_objectiveInitializer, 3, TeamName.Alpha);
            _objectiveManagerB.Init(_objectiveInitializer, 3, TeamName.Beta);

            _progressController = new SimpleProgressController(10, 100);
            //_objectiveIconViewA = new LogObjectiveIconView(_objectiveManagerA, TeamName.Alpha);
            //_objectiveIconViewB = new LogObjectiveIconView(_objectiveManagerB, TeamName.Beta);

            _simpleObjManagerA = new(TeamName.Alpha);
            _simpleObjManagerB = new(TeamName.Beta);
            _objectiveIconViewA = new LogObjectiveIconView(_simpleObjManagerA, TeamName.Alpha);
            _objectiveIconViewB = new LogObjectiveIconView(_simpleObjManagerB, TeamName.Beta);

            _simpleObjManagerA.OnObjectiveAchieved.AddListener((item) => _progressController.AddProgress(item));
            _objectiveManagerB.OnObjectiveAchieved.AddListener((item) => _progressController.AddProgress(item));
            //_objectiveManagerI = new ObjectiveManager(_leveledObjectiveCreator, 2);
            //_objectiveManagerA.OnNewObjectiveGenerated.AddListener((objectiveData) => _objectiveViewerFactory.Generate(objectiveData));
            //_objectiveManagerB.OnNewObjectiveGenerated.AddListener((objectiveData) => _objectiveViewerFactory.Generate(objectiveData));
            //_objectiveManagerA.OnObjectiveAchieved.AddListener((objectiveData) => _objectiveViewerFactory.DeleteViewer(objectiveData));
            //_objectiveManagerB.OnObjectiveAchieved.AddListener((objectiveData) => _objectiveViewerFactory.DeleteViewer(objectiveData));
            if (PhotonNetwork.IsMasterClient)
            {
                //_objectiveManagerA.InitObjectives();
                _objectiveManagerB.InitObjectives();
                _simpleObjManagerA.InitObjectives();
                //_simpleObjManagerB.InitObjectives();
            }
            //_objectiveManagerI.InitObjectives();

            //ObjectiveProgressViewer
            //_objectiveProgressViewerA = new ObjectiveProgressViewer(_objectiveGaugeA, _objectiveManagerA, TeamName.Alpha);
            //_objectiveProgressViewerB = new ObjectiveProgressViewer(_objectiveGaugeB, _objectiveManagerB, TeamName.Beta);
            _objectiveProgressViewerA = new ObjectiveProgressViewer(_objectiveGaugeA, _progressController.MaxProgress);
            _objectiveProgressViewerB = new ObjectiveProgressViewer(_objectiveGaugeB, _progressController.MaxProgress);

            //_objectiveProgressViewerI = new ObjectiveProgressViewer(_objectiveGaugeI, _objectiveManagerI);

            _teamAlphaProgressCallback.onModified.AddListener((val) => _objectiveProgressViewerA.UpdateViewer(val));
            _teamBetaProgressCallback.onModified.AddListener((val) => _objectiveProgressViewerB.UpdateViewer(val));
            /*_objectivePropertyCallback.onModified.AddListener(val => {
                _objectiveProgressViewerA.UpdateViewer();
                _objectiveProgressViewerB.UpdateViewer();
            });*/
            /// Added by Shinnosuke (2025/1/3)

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
            //_objectiveCreatorPacer = new(new() { 20f }, false, true);
            //_objectiveCreatorPacer.OnCheckpointReached.AddListener((val) => _objectiveManager.AddNewObjective());
            //_objectiveCreatorPacer.IsActive = true;

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
            //_clock.AddTick(_objectiveCreatorPacer);
            _clock.AddTick(_roomParam);
            _clock.IsActive = true;

            //GameOver
            _gameOverProcess = new(_playerManager,_gameOverView);
            _roomParam.OnParamDead += () => SetGameOver();
            _gameoverPropertyCallback.onModified.AddListener(() => _gameOverProcess.RunGameOverProcess());
            _gameOverView.OnButtonClick.AddListener(() => PhotonNetwork.Disconnect());

            //Teleport System (Teleporters and Receivers)
            _teleporterReceiverInitializer = new(_playerManager, _teleporters, _receivers, _receiverCustomPropCallbacks, _e_keyDownController);
            _teleporterReceiverInitializer.InitializeGame();

            //Signal System
            _signalInitializer = new(_playerManager, _signalReceivers, _signalCustomPropCallbacks);
            _signalInitializer.InitializeGame();
            // Added by Shinnosuke (2024/12/13)

            //Player Information View
            _playerInfoInitializer = new(_playerManager, _viewers);
            _playerInfoInitializer.InitializeGame();
            // Added by Shinnosuke (2024/12/17)

            //SubmissionSpace
            //List<IObjectiveManager> objManagers = new List<IObjectiveManager> { _objectiveManagerA, _objectiveManagerB };
            List<IObjectiveManager> objManagers = new List<IObjectiveManager> { _simpleObjManagerA, _objectiveManagerB };
            _submissionWorkSpaceControllerFactory = new(_playerManager, objManagers, _roomParamModifier,_e_keyDownController);
            _submissionSpace.SetWorkSpaceManager(_submissionWorkSpaceControllerFactory.GenerateWorkSpaceManager(_submissionSpace));

            //Bed
            _bedWorkSpaceControllerFactory = new(_playerManager, _clock,_f_keyDownController);
            _bed.SetWorkSpaceManager(_bedWorkSpaceControllerFactory.GenerateWorkSpaceManager(_bed));

        }

        public async UniTask SetGameOver()
        {
            await UniTask.Delay(10);
            PhotonNetwork.CurrentRoom.SetGameOver(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                _objectiveIconViewA.ShowObjectiveIcon();
                _objectiveIconViewB.ShowObjectiveIcon();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                SetGameOver();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log($"Team : {_teamSetter.GetTeam(PhotonNetwork.LocalPlayer)}");
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Disconnected");
            SceneLoadManager.MoveToTitle();
        }
    }
}