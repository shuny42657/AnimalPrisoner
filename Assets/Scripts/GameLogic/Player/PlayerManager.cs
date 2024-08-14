using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;


namespace GameLogic.GamePlayer
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] SerializeInterface<IOperatableHandler> opertableHandler;
        [SerializeField] SerializeInterface<IPlayerStatus> playerStatus;
        [SerializeField] SerializeInterface<IJobStatus> jobStatus;
        [SerializeField] SerializeInterface<IMovable> characterMove;

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

