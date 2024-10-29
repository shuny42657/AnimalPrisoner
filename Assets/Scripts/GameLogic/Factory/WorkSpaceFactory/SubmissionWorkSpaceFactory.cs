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
            return new PutTakeWorkSpaceController(_player, objectiveManagerPutAndTake, _keyDownController);
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

            return new PutTakeWorkWorkSpaceController(_player, onlyTakeWithSettable,work, _e_keyDownController, _q_keyHoldController);
        }
    }

    public class FloorWorkSpaceControllerFactory : IWorkSpaceControllerFactory
    {
        IPlayer _player;
        KeyDownController _keyDownController;

        public FloorWorkSpaceControllerFactory(IPlayer player, KeyDownController keyDownController)
        {
            _player = player;
            _keyDownController = keyDownController;
        }

        public IWorkSpaceController GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var basicPutAndTake = new BasicPutAndTake();
            basicPutAndTake.OnPut.AddListener((item) => workSpace.GrabbableVisualizer.Show(item));
            basicPutAndTake.OnTake.AddListener(workSpace.GrabbableVisualizer.Delete);

            return new PutTakeWorkSpaceController(_player, basicPutAndTake,_keyDownController);
        }
    }

    public class CrafterWorkSpaceControllerFacotry : IWorkSpaceControllerFactory
    {
        IPlayer _player;
        IClock _clock;
        KeyDownController _e_keyDownController;
        KeyDownController _f_keyDownController;
        ItemName _firstItem;
        ItemName _secondItem;

        public CrafterWorkSpaceControllerFacotry(IPlayer player,IClock clock,ItemName firstItem,ItemName secondItem, KeyDownController e_keyDownController,KeyDownController f_keyDownController)
        {
            _player = player;
            _clock = clock;
            _e_keyDownController = e_keyDownController;
            _f_keyDownController = f_keyDownController;
            _firstItem = firstItem;
            _secondItem = secondItem;
        }

        public IWorkSpaceController GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var crafterPutAndTake = new CrafterPutAndTake(_firstItem, _secondItem);
            var crafterAutomatable = new CrafterAutomatable(5f, crafterPutAndTake);

            crafterPutAndTake.OnTake.AddListener(() => workSpace.GrabbableVisualizer.Delete());
            crafterPutAndTake.OnSet.AddListener((item) => workSpace.GrabbableVisualizer.Show(item));

            crafterAutomatable.OnOperationInitiated.AddListener(() => crafterPutAndTake.ResetSetQuantity());
            crafterAutomatable.OnOperationInitiated.AddListener(() => workSpace.WorkSapceProgressView.Show(true));
            crafterAutomatable.OnProgressMade.AddListener((rate) => workSpace.WorkSapceProgressView.ModifyGauge(rate));
            crafterAutomatable.OnOperationFinish.AddListener(() => crafterPutAndTake.Set());
            crafterAutomatable.OnOperationFinish.AddListener(() => workSpace.WorkSapceProgressView.Show(false));

            _clock.AddTick(crafterAutomatable);
            return new PutTakeAutomateWorkSpaceController(_player, crafterPutAndTake, crafterAutomatable, _e_keyDownController, _f_keyDownController);
        }
    }
}
