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
        IJobAllocator _jobAllocator;
        RoomParameter _roomParam;
        Pacer _roomParamPacer;
        Pacer _leveledObjCreatorPacer;
        Pacer _objectiveCreatorPacer;
        public MainGameInitializer(
            IJobAllocator jobAllocator,
            RoomParameter roomParam,
            Pacer roomParamPacer,
            Pacer leveledObjCreatorPacer,
            Pacer objectiveCreatorPacer
            )
        {
            _jobAllocator = jobAllocator;
            _roomParam = roomParam;
            _roomParamPacer = roomParamPacer;
            _leveledObjCreatorPacer = leveledObjCreatorPacer;
            _objectiveCreatorPacer = objectiveCreatorPacer;

        }
        public void InitializeGame()
        {

            _jobAllocator.AllocateJob();

            _roomParam.FuelComsumeSpeed = 5f;
            _roomParam.DuranilityCosumeSpeed = 5f;
            _roomParam.ElectricityConsumeSpeed = 5f;
            _roomParam.IsActive = true;

            _roomParamPacer.IsActive = true;
            _leveledObjCreatorPacer.IsActive = true;
            _objectiveCreatorPacer.IsActive = true;
        }
    }
}
