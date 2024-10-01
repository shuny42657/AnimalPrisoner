using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using GameLogic.WorkSpace;

namespace GameLogic.GamePlayer
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] SerializeInterface<IOperatableHandler> opertableHandler;
        [SerializeField] SerializeInterface<IPlayerStatus> playerStatus; public IPlayerStatus PlayerStatus { get { return playerStatus.Value; } }
        [SerializeField] SerializeInterface<IJobStatus> jobStatus;
        [SerializeField] SerializeInterface<IMovable> characterMove;
        [SerializeField] SerializeInterface<IUpGradable> upGradable; public IUpGradable UpGradable { get { return upGradable.Value; } }

        public void Work()
        {
            opertableHandler.Value.Work(playerStatus.Value);
        }

        public void SetCanMove(bool isActive)
        {
            characterMove.Value.CanMove = isActive;
        }
    }
}

