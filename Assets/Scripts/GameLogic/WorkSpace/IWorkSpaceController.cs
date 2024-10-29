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
}
