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
        public IWorkSpaceController GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace);
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
        public IWorkSpaceController GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var objectiveManagerPutAndTake = new ObjectiveMangerPutAndTake(_objectiveManager, _roomParamModifier);
            return new SubmissionWorkSpaceController(_player, objectiveManagerPutAndTake, _keyDownController);
        }
    }

    public class MakerWorkSpaceControllerFactory : IWorkSpaceControllerFactory
    {
        IPlayer _player;
        ItemName _itemName;
        KeyDownController _e_keyDownController;
        KeyHoldController _q_keyHoldController;

        public MakerWorkSpaceControllerFactory(IPlayer player,ItemName itemName,KeyDownController e_keyDownController,KeyHoldController q_keyHoldController)
        {
            _player = player;
            _itemName = itemName;
            _e_keyDownController = e_keyDownController;
            _q_keyHoldController = q_keyHoldController;
        }

        public IWorkSpaceController GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var onlyTakeWithSettable = new OnlyTakeWithSettable(_itemName);
            var work = new MakerWork(5f);

            onlyTakeWithSettable.OnSet.AddListener((item) => workSpace.GrabbableVisualizer.Show(item));
            onlyTakeWithSettable.OnTake.AddListener(() => workSpace.GrabbableVisualizer.Delete());
            onlyTakeWithSettable.OnTake.AddListener(() => work.ClearSpace(true));

            work.OnWorkStart.AddListener(() => workSpace.WorkSapceProgressView.Show(true));

            work.OnWorkFinish.AddListener(() => workSpace.WorkSapceProgressView.Show(false));
            work.OnWorkFinish.AddListener(() => onlyTakeWithSettable.Set());
            work.OnWorkFinish.AddListener(() => work.ClearSpace(false));

            work.OnProgressMade.AddListener((rate) => workSpace.WorkSapceProgressView.ModifyGauge(rate));

            return new MakerWorkSpaceController(_player, onlyTakeWithSettable,work, _e_keyDownController, _q_keyHoldController);
        }
    }
}
