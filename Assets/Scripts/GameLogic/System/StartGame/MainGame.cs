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

namespace GameLogic.GameSystem
{
    /// <summary>
    /// インゲームのトップレベルコンポーネント
    /// </summary>
    public class MainGame : MonoBehaviourPunCallbacks
    {
        IPlayer _playerManager;
        MainGameInitializer gameInitializer;
        
        [SerializeField] MainPlayer playerFactory;
        [SerializeField] IJobAllocator jobAllocator = new FixedJobAllocater();

        [SerializeField] ObjectiveManager _objectiveManager;
        [SerializeField] ItemDataBase _itemDataBase;
        RoomParameterUpgrader _roomParamUpGrader;
        [SerializeField] LeveledObjectiveCreator _leveledObjectiveCreator;
        [SerializeField] RoomIntegerPropertyCallback _decayLevelUpCallback;

        [SerializeField] UpdateClock _clock;
        RoomParameter _roomParam;
        RoomParameterModifier _roomParamModifier;
        Pacer _roomParamPacer;
        Pacer _leveledObjCreatorPacer;
        Pacer _objectiveCreatorPacer;

        [SerializeField] MotherWorkSpaceFactory _motherWorkSpaceFactory;
        SubmissionWorkSpaceControllerFactory _submissionWorkSpaceControllerFactory;

        //View
        [SerializeField] GameOverProcess _gameOverProcess;
        [SerializeField] GameOverView _gameOverView;
        [SerializeField] GaugeView _fuelGauge;
        [SerializeField] GaugeView _durabilityGauge;
        [SerializeField] GaugeView _electricityGauge;

        [SerializeField] RoomPredicatePropertyCallback _roomPredicatePropertyCallback;

        [SerializeField] List<BaseWorkSpace> _teleporters;
        [SerializeField] List<BaseWorkSpace> _receivers;
        [SerializeField] WorkSpace.WorkSpace _submissionSpace;
        [SerializeField] BaseWorkSpace _bed;

        //Controller
        [SerializeField] KeyDownController e_KeyDownController;

        // Start is called before the first frame update
        void Start()
        {
            _playerManager = playerFactory.GeneratePlayer(Vector3.zero);
            _playerManager.SetCanMove(true);
            _motherWorkSpaceFactory.SetPlayer(_playerManager);
            //プレイヤーの数が揃っていなかった場合は例外処理を飛ばしてマッチングシーンに戻る
            Debug.Log($"Player Count : {PhotonNetwork.PlayerList.Length}");

            //RoomParameterの初期化
            _roomParam = new(
                200f,
                200f,
                200f,
                5f, 5f, 5f
                );
            //RoomParameterUpgraderの初期化
            _roomParamUpGrader = new(
                _roomParam,
                new() { 1f, 2f, 3f, 4f, 5f },
                new() { 1f, 2f, 3f, 4f, 5f },
                new() { 1f, 2f, 3f, 4f, 5f });
            _decayLevelUpCallback.onModified.AddListener((val) => _roomParamUpGrader.UpGrade());
            //RoomParameterModifierの初期化
            _roomParamModifier = new(_itemDataBase, _roomParam);

            _roomParam.OnFuelModified.AddListener((rate) => _fuelGauge.ModifyGauge(rate));
            _roomParam.OnDurabilityModified.AddListener((rate) => _durabilityGauge.ModifyGauge(rate));
            _roomParam.OnElectricityModified.AddListener((rate) => _electricityGauge.ModifyGauge(rate));

            //Pacerの初期化
            ///RoomParamPacer
            _roomParamPacer = new(new(){ 10f,10f,10f,10f},true, false);
            _roomParamPacer.OnCheckpointReached.AddListener((val) => _roomParamUpGrader.IncrementLevel(val));

            ///LeveledObjCreatorPacer
            _leveledObjCreatorPacer = new(new(){10f,10f,10f,10},false, false);
            _leveledObjCreatorPacer.OnCheckpointReached.AddListener((val) => _leveledObjectiveCreator.UpGrade());

            ///ObjectiveCreatorPacer
            _objectiveCreatorPacer = new(new() { 20f},false, true);
            _objectiveCreatorPacer.OnCheckpointReached.AddListener((val) => _objectiveManager.AddNewObjective());


            //メインの処理
            gameInitializer = new(
                jobAllocator,
                _roomParam,
                _roomParamPacer,
                _leveledObjCreatorPacer,
                _objectiveCreatorPacer
                );


            gameInitializer.InitializeGame();

            //UpdateClockへのPacerの登録
            _clock.AddTick(_roomParamPacer);
            _clock.AddTick(_leveledObjCreatorPacer);
            _clock.AddTick(_objectiveCreatorPacer);
            _clock.AddTick(_roomParam);
            _clock.IsActive = true;

            //ゲームオーバーの関数の登録
            _roomParam.OnParamDead += () => SetGameOver();
            //_roomPredicatePropertyCallback.onModified.AddListener(() => Debug.Log("Predicate Callback"));
            _roomPredicatePropertyCallback.onModified.AddListener(() => _gameOverProcess.RunGameOverProcess(_playerManager));

            //GameOverViewのボタンコールバック
            _gameOverView.OnButtonClick.AddListener(() => PhotonNetwork.Disconnect());

            //固定配置されているワークスペースの初期化
            for(int i = 0; i < _teleporters.Count; i++)
            {
                _teleporters[i].InitializeWorkSpace();
                _receivers[i].InitializeWorkSpace();
            }

            //SubmissionWorkSpace
            _submissionWorkSpaceControllerFactory = new(_playerManager, _objectiveManager, _roomParamModifier,e_KeyDownController);
            _submissionSpace.SetWorkSpaceController(_submissionWorkSpaceControllerFactory.GenerateWorkSpaceController(_submissionSpace));
            _bed.InitializeWorkSpace();
            
        }

        public async UniTask SetGameOver()
        {
            await UniTask.Delay(100);
            PhotonNetwork.CurrentRoom.SetGameOver(true);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.Log("Disconnected");
            SceneLoadManager.MoveToTitle();
        }
    }
}
