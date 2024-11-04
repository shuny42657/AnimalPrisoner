using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using GameLogic.GamePlayer;

namespace GameLogic.WorkSpace
{
    public interface IWorkSpaceInteraction
    {
        public void Subscribe(); //キー入力による処理を登録する。
        public void UnSubscribe(); //処理の登録を解除する。
    }

    //Put&Take
    public class PutTakeWorkSpaceInteraction : IWorkSpaceInteraction
    {
        IPlayer _player;
        IPutAndTake _putAndTake; //ObjectiveMangerPutAndTake
        KeyDownController _keyDownController;

        public PutTakeWorkSpaceInteraction(IPlayer player,IPutAndTake putAndTake,KeyDownController keyDownController)
        {
            _player = player;
            _putAndTake = putAndTake;
            _keyDownController = keyDownController;
        }

        public void Subscribe()
        {
            //Debug.Log("Floor SubScribed");
            _keyDownController.OnKeyPressed.AddListener(() => Debug.Log("Key Pressed"));
            _keyDownController.OnKeyPressed.AddListener(() => _player.PutOrTake(_putAndTake));
        }

        public void UnSubscribe()
        {
            _keyDownController.OnKeyPressed.RemoveAllListeners();
            //_keyDownController.OnKeyPressed.RemoveListener(() => _player.PutOrTake(_putAndTake));
        }
    }

    //Put&Take, Work
    public class PutTakeWorkWorkSpaceInteraction : IWorkSpaceInteraction
    {
        IPlayer _player;
        IPutAndTake _putAndTake;
        IWork _work;
        KeyDownController _e_keyDownController;
        KeyHoldController _q_keyHoldController;

        public PutTakeWorkWorkSpaceInteraction(
            IPlayer player,
            IPutAndTake putAndTake,
            IWork work,
            KeyDownController e_keyDownController,
            KeyHoldController q_keyHoldController
            )
        {
            _player = player;
            _putAndTake = putAndTake;
            _work = work;
            _e_keyDownController = e_keyDownController;
            _q_keyHoldController = q_keyHoldController;
        }

        public void Subscribe()
        {
            _e_keyDownController.OnKeyPressed.AddListener(() => _player.PutOrTake(_putAndTake));
            _q_keyHoldController.OnKeyHold.AddListener(() => _player.Work(_work));
        }

        public void UnSubscribe()
        {
            //_e_keyDownController.OnKeyPressed.RemoveListener(() => _player.PutOrTake(_putAndTake));
            //_q_keyHoldController.OnKeyHold.RemoveListener(() => _player.Work(_work));
            _e_keyDownController.OnKeyPressed.RemoveAllListeners();
            _q_keyHoldController.OnKeyHold.RemoveAllListeners();
        }
    }

    //Work
    public class AutomateWorkSpaceInteraction : IWorkSpaceInteraction
    {
        IPlayer _player;
        IAutomatable _automatable;
        KeyDownController _f_keyDownController;

        public AutomateWorkSpaceInteraction(
            IPlayer player,
            IAutomatable automatable,
            KeyDownController q_keyHoldContrller
            )
        {
            _player = player;
            _automatable = automatable;
            _f_keyDownController = q_keyHoldContrller;
        }

        public void Subscribe()
        {
            _f_keyDownController.OnKeyPressed.AddListener(() => _player.StartOperation(_automatable));
        }

        public void UnSubscribe()
        {
            _f_keyDownController.OnKeyPressed.RemoveAllListeners();
        }
    }

    //Put&Take, Automate
    public class PutTakeAutomateWorkSpaceInteraction : IWorkSpaceInteraction
    {
        IPlayer _player;
        IPutAndTake _putAndTake;
        IAutomatable _automatable;
        KeyDownController _e_keyDownController;
        KeyDownController _f_keyHoldController;

        public PutTakeAutomateWorkSpaceInteraction(
            IPlayer player,
            IPutAndTake putAndTake,
            IAutomatable automatable,
            KeyDownController e_keyDownController,
            KeyDownController f_keyDownController
            )
        {
            _player = player;
            _putAndTake = putAndTake;
            _automatable = automatable;
            _e_keyDownController = e_keyDownController;
            _f_keyHoldController = f_keyDownController;
        }

        public void Subscribe()
        {
            _e_keyDownController.OnKeyPressed.AddListener(() => _player.PutOrTake(_putAndTake));
            _f_keyHoldController.OnKeyPressed.AddListener(() => _player.StartOperation(_automatable));
        }

        public void UnSubscribe()
        {
            _e_keyDownController.OnKeyPressed.RemoveAllListeners();
            _f_keyHoldController.OnKeyPressed.RemoveAllListeners();
        }
    }
}
