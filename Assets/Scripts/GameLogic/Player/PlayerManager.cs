using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using GameLogic.WorkSpace;

namespace GameLogic.GamePlayer
{
    public class PlayerManager : IPlayer,IUpGradable
    {
        public PlayerManager(
            IOperatableHandler operatableHandler,
            IPlayerStatus playerStatus,
            IJobStatus jobStatus,
            IMovable movable,
            IUpGradable upgradable
            )
        {
            _operatableHandler = operatableHandler;
            _playerStatus = playerStatus;
            _jobStatus = jobStatus;
            _movable = movable;
            _upgradable = upgradable;
        }
        IOperatableHandler _operatableHandler;
        IPlayerStatus _playerStatus; public IPlayerStatus PlayerStatus { get { return _playerStatus; } }
        IJobStatus _jobStatus;
        IMovable _movable;
        IUpGradable _upgradable; public IUpGradable UpGradable { get { return _upgradable; } }

        public void Work(IWork work)
        {
            _operatableHandler.Work(work,_playerStatus);
        }

        public void SetCanMove(bool isActive)
        {
            _movable.CanMove = isActive;
        }

        public void PutOrTake(IPutAndTake putAndTake)
        {
            _operatableHandler.PutOrTake(putAndTake);
        }

        public void StartOperation(IAutomatable automatable)
        {
            _operatableHandler.InitiateWork(automatable);
        }

        //Move
        public void MoveRight()
        {
            _movable.MoveHorizontal(_movable.Speed);
        }

        public void MoveLeft()
        {
            _movable.MoveHorizontal(_movable.Speed * -1f);
        }

        public void MoveUp()
        {
            _movable.MoveVertical(_movable.Speed);
        }

        public void MoveDown()
        {
            _movable.MoveVertical(_movable.Speed * -1);
        }

        public void UpGrade()
        {
            _upgradable.UpGrade();
        }

        public void HealEnergy()
        {
            _playerStatus.Energy = _playerStatus.MaxEnergy;
        }

        public UpGraderName UpGraderName { get { return _upgradable.UpGraderName; } }
    }
}