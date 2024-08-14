using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;

namespace GameLogic.GameSystem
{
    public class PlayerStopPlayingManager : MonoBehaviour
    {
        PlayerManager playerManager; public void SetPlayerManager(PlayerManager playerManager) { this.playerManager = playerManager; }

        public void StopPlaying()
        {
            playerManager.SetCanMove(false);
            Debug.Log("Player Dead");
        }
    }
}
