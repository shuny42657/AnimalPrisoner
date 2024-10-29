using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using GameLogic.GamePlayer;

namespace GameLogic.WorkSpace
{
    public interface IWorkSpaceController
    {
        public void Subscribe(); //キー入力による処理を登録する。
        public void UnSubscribe(); //処理の登録を解除する。
    }

    public class SubmissionWorkSpaceController : IWorkSpaceController
    {
        IPlayer _player;
        IPutAndTake _putAndTake; //ObjectiveMangerPutAndTake
        KeyDownController _keyDownController;

        public SubmissionWorkSpaceController(IPlayer player,IPutAndTake putAndTake,KeyDownController keyDownController)
        {
            _player = player;
            _putAndTake = putAndTake;
            _keyDownController = keyDownController;
        }

        public void Subscribe()
        {
            _keyDownController.OnKeyPressed.AddListener(() => _player.PutOrTake(_putAndTake));
        }

        public void UnSubscribe()
        {
            _keyDownController.OnKeyPressed.RemoveListener(() => _player.PutOrTake(_putAndTake));
        }
    }

    public class MakerWorkSpaceController : IWorkSpaceController
    {
        IPlayer _player;
        IPutAndTake _putAndTake;
        IWork _work;
        KeyDownController _e_keyDownController;
        KeyHoldController _q_keyHoldController;

        public MakerWorkSpaceController(
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
            _e_keyDownController.OnKeyPressed.RemoveListener(() => _player.PutOrTake(_putAndTake));
            _q_keyHoldController.OnKeyHold.RemoveListener(() => _player.Work(_work));
        }
    }
}
