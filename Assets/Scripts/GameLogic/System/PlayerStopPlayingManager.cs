using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using Cysharp.Threading.Tasks;
using System;

namespace GameLogic.GameSystem
{
    public interface IPlayStopper
    {
        public UniTask StopPlaying();
    }

    public class PlayerStopPlayingManager : MonoBehaviour
    {
        [SerializeField]PlayerManager playerManager; public void SetPlayerManager(PlayerManager playerManager) { this.playerManager = playerManager; }

        public void StopPlaying()
        {
            playerManager.SetCanMove(false);
            Debug.Log("Player Dead");
        }
    }

    public class PlayStopper : IPlayStopper
    {
        PlayerManager _playerManager;
        public PlayStopper(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }
        public async UniTask StopPlaying()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            _playerManager.SetCanMove(false);
        }
    }
}
