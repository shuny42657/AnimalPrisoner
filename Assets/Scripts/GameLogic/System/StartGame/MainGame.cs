using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Factory;
using Photon.Pun;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// インゲームのトップレベルコンポーネント
    /// </summary>
    public class MainGame : MonoBehaviour
    {
        MainGameInitializer gameInitializer;

        [SerializeField] PlayerFactory playerFactory;
        [SerializeField] IJobAllocator jobAllocator = new MainJobAllocator();
        [SerializeField] RoomParameter roomParam;
        [SerializeField] Pacer roomParamPacer;
        [SerializeField] Pacer leveledObjCreatorPacer;
        [SerializeField] Pacer objectiveCreatorPacer;
        // Start is called before the first frame update
        void Start()
        {
            //プレイヤーの数が揃っていなかった場合は例外処理を飛ばしてマッチングシーンに戻る

            //メインの処理
            gameInitializer = new(
                playerFactory,
                jobAllocator,
                roomParam,
                roomParamPacer,
                leveledObjCreatorPacer,
                objectiveCreatorPacer
                );

            gameInitializer.InitializeGame();
        }
    }
}
