using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using GameLogic.WorkSpace;
using GameLogic.GamePlayer;
using Util;
using UI;
using Photon.Pun;
using Photon.Realtime;
using Sync;

namespace GameLogic.Factory
{
    public interface IWorkSpaceManagerFactory
    {
        public WorkSpaceManager GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace);
    }

    public class SubmissionWorkSpaceManagerFactory : IWorkSpaceManagerFactory
    {
        IPlayer _player;
        ObjectiveManager _objectiveManager;
        RoomParameterModifier _roomParamModifier;
        KeyDownController _keyDownController;

        public SubmissionWorkSpaceManagerFactory(
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
        public WorkSpaceManager GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var objectiveManagerPutAndTake = new ObjectiveMangerPutAndTake(_objectiveManager, _roomParamModifier);
            return new WorkSpaceManager(new PutTakeWorkSpaceController(_player, objectiveManagerPutAndTake, _keyDownController), new NullUpGradable());
        }
    }

    public class MakerWorkSpaceManagerFactory : IWorkSpaceManagerFactory
    {
        IPlayer _player;
        ItemName _itemName;
        UpGraderName _upGraderName;
        KeyDownController _e_keyDownController;
        KeyHoldController _q_keyHoldController;

        public MakerWorkSpaceManagerFactory(IPlayer player,ItemName itemName,UpGraderName upGraderName, KeyDownController e_keyDownController,KeyHoldController q_keyHoldController)
        {
            _player = player;
            _itemName = itemName;
            _upGraderName = upGraderName;
            _e_keyDownController = e_keyDownController;
            _q_keyHoldController = q_keyHoldController;
        }

        public WorkSpaceManager GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var onlyTakeWithSettable = new OnlyTakeWithSettable(_itemName);
            var work = new MakerWork(5f);
            var upgradable = new WorkSpeedUpgradable(work, new() { 1f, 1.2f, 1.5f, 1.8f, 2.0f }, _upGraderName);

            onlyTakeWithSettable.OnSet.AddListener((item) => workSpace.GrabbableVisualizer.Show(item));
            onlyTakeWithSettable.OnTake.AddListener(() => workSpace.GrabbableVisualizer.Delete());
            onlyTakeWithSettable.OnTake.AddListener(() => work.ClearSpace(true));

            work.OnWorkStart.AddListener(() => workSpace.WorkSapceProgressView.Show(true));

            work.OnWorkFinish.AddListener(() => workSpace.WorkSapceProgressView.Show(false));
            work.OnWorkFinish.AddListener(() => onlyTakeWithSettable.Set());
            work.OnWorkFinish.AddListener(() => work.ClearSpace(false));

            work.OnProgressMade.AddListener((rate) => workSpace.WorkSapceProgressView.ModifyGauge(rate));

            return new WorkSpaceManager(new PutTakeWorkWorkSpaceController(_player, onlyTakeWithSettable,work, _e_keyDownController, _q_keyHoldController),upgradable);
        }
    }

    public class FloorWorkSpaceManagerFactory : IWorkSpaceManagerFactory
    {
        IPlayer _player;
        KeyDownController _keyDownController;

        public FloorWorkSpaceManagerFactory(IPlayer player, KeyDownController keyDownController)
        {
            _player = player;
            _keyDownController = keyDownController;
        }

        public WorkSpaceManager GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var basicPutAndTake = new BasicPutAndTake();
            basicPutAndTake.OnPut.AddListener((item) => workSpace.GrabbableVisualizer.Show(item));
            basicPutAndTake.OnTake.AddListener(workSpace.GrabbableVisualizer.Delete);

            return new WorkSpaceManager(new PutTakeWorkSpaceController(_player, basicPutAndTake,_keyDownController),new NullUpGradable());
        }
    }

    public class CrafterWorkSpaceManagerFacotry : IWorkSpaceManagerFactory
    {
        IPlayer _player;
        IClock _clock;
        KeyDownController _e_keyDownController;
        KeyDownController _f_keyDownController;
        ItemName _firstItem;
        ItemName _secondItem;
        UpGraderName _upGraderName;

        public CrafterWorkSpaceManagerFacotry(IPlayer player,IClock clock,ItemName firstItem,ItemName secondItem,UpGraderName upGraderName, KeyDownController e_keyDownController,KeyDownController f_keyDownController)
        {
            _player = player;
            _clock = clock;
            _e_keyDownController = e_keyDownController;
            _f_keyDownController = f_keyDownController;
            _firstItem = firstItem;
            _secondItem = secondItem;
            _upGraderName = upGraderName;
        }

        public WorkSpaceManager GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
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
            return new WorkSpaceManager(new PutTakeAutomateWorkSpaceController(_player, crafterPutAndTake, crafterAutomatable, _e_keyDownController, _f_keyDownController), new AutomateSpeedUpGradable(crafterAutomatable, _upGraderName, new() { 1f,1.2f,1.5f,1.8f,2.0f}));
        }
    }

    public class TeleporterWorkSpaceManagerFactory : IWorkSpaceManagerFactory
    {
        IPlayer _player;
        KeyDownController _e_keyDownController;
        ITextView<int> _teleporterTextView;
        Player _receiver;

        public TeleporterWorkSpaceManagerFactory(
            IPlayer player,
            KeyDownController e_keyDownController,
            ITextView<int> teleporterTextView,
            Player receiver
            )
        {
            _player = player;
            _e_keyDownController = e_keyDownController;
            _teleporterTextView = teleporterTextView;
            _receiver = receiver;
        }

        public WorkSpaceManager GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var teleporterPutAndTake = new TeleporterPutAndTake(_receiver);
            _teleporterTextView.ShowText(_receiver.ActorNumber);

            //teleporterPutAndTake.OnPut.AddListener((item) => _player.PutOrTake(teleporterPutAndTake));

            return new WorkSpaceManager(new PutTakeWorkSpaceController(_player, teleporterPutAndTake, _e_keyDownController), new NullUpGradable());
        }
    }

    public class ReceiverWorkSpaceManagerFactory : IWorkSpaceManagerFactory
    {
        IPlayer _player;
        KeyDownController _e_keyDownController;
        ITextView<int> _receiverTextView;
        PlayerCustomPropertyCallback _playerCustomPropCallback;
        int _senderId;

        public ReceiverWorkSpaceManagerFactory(
            IPlayer player,
            KeyDownController e_keyDownController,
            ITextView<int> receiverTextView,
            PlayerCustomPropertyCallback playerCustomPropCallback,
            int senderId
            )
        {
            _player = player;
            _e_keyDownController = e_keyDownController;
            _receiverTextView = receiverTextView;
            _playerCustomPropCallback = playerCustomPropCallback;
            _senderId = senderId;
        }

        public WorkSpaceManager GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var receiverPutAndTake = new ReceierPutAndTake(_senderId);
            _receiverTextView.ShowText(_senderId);
            _playerCustomPropCallback.onComplete.AddListener(() => receiverPutAndTake.Set());
            receiverPutAndTake.OnSet.AddListener((item) => workSpace.GrabbableVisualizer.Show(item));
            receiverPutAndTake.OnTake.AddListener(() => workSpace.GrabbableVisualizer.Delete());

            return new WorkSpaceManager(new PutTakeWorkSpaceController(_player, receiverPutAndTake, _e_keyDownController), new NullUpGradable());
        }
    }

    public class BedWorkSpaceManagerFacotry : IWorkSpaceManagerFactory
    {
        IPlayer _player;
        IClock _clock;
        KeyDownController _f_keyDownController;

        public BedWorkSpaceManagerFacotry(
            IPlayer player,
            IClock clock,
            KeyDownController f_keyDownController
            )
        {
            _player = player;
            _clock = clock;
            _f_keyDownController = f_keyDownController;
        }

        public WorkSpaceManager GenerateWorkSpaceController(WorkSpace.WorkSpace workSpace)
        {
            var automatable = new SimpleAutomatable(5f);

            automatable.OnOperationInitiated.AddListener(() => workSpace.WorkSapceProgressView.Show(true));
            automatable.OnOperationInitiated.AddListener(() => _player.SetCanMove(false));
            automatable.OnProgressMade.AddListener((rate) => workSpace.WorkSapceProgressView.ModifyGauge(rate));

            automatable.OnOperationFinish.AddListener(() => _player.SetCanMove(true));
            automatable.OnOperationFinish.AddListener(() => _player.HealEnergy());
            automatable.OnOperationFinish.AddListener(() => workSpace.WorkSapceProgressView.Show(false));

            _clock.AddTick(automatable);
            return new WorkSpaceManager(new AutomateWorkSpaceController(_player, automatable, _f_keyDownController), new NullUpGradable());
        }
    }
}
