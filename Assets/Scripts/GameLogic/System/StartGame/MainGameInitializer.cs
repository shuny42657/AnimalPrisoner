using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Factory;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// 本番用のゲームシーンで使用するイニシャライザ
    /// </summary>
    public class MainGameInitializer : IGameInitializer
    {
        IPlayerFactory _playerFactory;
        IJobAllocator _jobAllocator;
        RoomParameter _roomParam;
        Pacer _roomParamPacer;
        Pacer _leveledObjCreatorPacer;
        Pacer _objectiveCreatorPacer;
        public MainGameInitializer(
            IPlayerFactory playerFactory,
            IJobAllocator jobAllocator,
            RoomParameter roomParam,
            Pacer roomParamPacer,
            Pacer leveledObjCreatorPacer,
            Pacer objectiveCreatorPacer
            )
        {
            _playerFactory = playerFactory;
            _jobAllocator = jobAllocator;
            _roomParam = roomParam;
            _roomParamPacer = roomParamPacer;
            _leveledObjCreatorPacer = leveledObjCreatorPacer;
            _objectiveCreatorPacer = objectiveCreatorPacer;

        }
        public void InitializeGame()
        {
            _playerFactory.GeneratePlayer(new Vector3(0, 0, 0));

            _jobAllocator.AllocateJob();

            _roomParam.FuelComsumeSpeed = 0.1f;
            _roomParam.DuranilityCosumeSpeed = 0.1f;
            _roomParam.ElectricityConsumeSpeed = 0.1f;
            _roomParam.IsActive = true;

            _roomParamPacer.IsActive = true;
            _leveledObjCreatorPacer.IsActive = true;
            _objectiveCreatorPacer.IsActive = true;
        }
    }

}
