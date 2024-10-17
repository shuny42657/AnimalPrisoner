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
        [SerializeField] IJobAllocator jobAllocator = new MainJobAllocator();
        [SerializeField] RoomParameter roomParam;
        [SerializeField] Pacer roomParamPacer;
        [SerializeField] Pacer leveledObjCreatorPacer;
        [SerializeField] Pacer objectiveCreatorPacer;

        [SerializeField] GameOverProcess _gameOverProcess;
        [SerializeField] GameOverView _gameOverView;

        [SerializeField] RoomPredicatePropertyCallback _roomPredicatePropertyCallback;
        // Start is called before the first frame update
        void Start()
        {
            _playerManager = playerFactory.GeneratePlayer(Vector3.zero);
            //プレイヤーの数が揃っていなかった場合は例外処理を飛ばしてマッチングシーンに戻る
            Debug.Log($"Player Count : {PhotonNetwork.PlayerList.Length}");
            //メインの処理
            gameInitializer = new(
                jobAllocator,
                roomParam,
                roomParamPacer,
                leveledObjCreatorPacer,
                objectiveCreatorPacer
                );

            gameInitializer.InitializeGame();

            //ゲームオーバーの関数の登録
            roomParam.OnParamDead += () => SetGameOver();
            //_roomPredicatePropertyCallback.onModified.AddListener(() => Debug.Log("Predicate Callback"));

            //GameOverViewのボタンコールバック
            _gameOverView.OnButtonClick.AddListener(() => PhotonNetwork.Disconnect());
            
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
