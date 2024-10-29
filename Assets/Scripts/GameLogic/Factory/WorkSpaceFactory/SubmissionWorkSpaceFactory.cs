using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using GameLogic.WorkSpace;
using GameLogic.GamePlayer;
using Util;

namespace GameLogic.Factory
{
    public interface IWorkSpaceControllerFactory
    {
        public IWorkSpaceController GenerateWorkSpaceController();
    }

    public class SubmissionWorkSpaceControllerFactory : IWorkSpaceControllerFactory
    {
        IPlayer _player;
        ObjectiveManager _objectiveManager;
        RoomParameterModifier _roomParamModifier;
        KeyDownController _keyDownController;

        public SubmissionWorkSpaceControllerFactory(
            IPlayer player,
            ObjectiveManager objectiveManager,
            RoomParameterModifier roomParamModifier,
            KeyDownController keyDownController
            )
        {
            _player = player;
            _objectiveManager = objectiveManager;
            _roomParamModifier = roomParamModifier;
            _keyDownController = keyDownController;
        }
        public IWorkSpaceController GenerateWorkSpaceController()
        {
            var objectiveManagerPutAndTake = new ObjectiveMangerPutAndTake(_objectiveManager, _roomParamModifier);
            return new SubmissionWorkSpaceController(_player, objectiveManagerPutAndTake, _keyDownController);
        }
    }
}
