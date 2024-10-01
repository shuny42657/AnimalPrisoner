using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using GameLogic.GameSystem;

public class P_PlayerStopPlayingManager : MonoBehaviour
{
    [SerializeField] PlayerStopPlayingManager pspManager;
    public void SetPlayerManager (GameObject player)
    {
        var playerManager = player.GetComponent<PlayerManager>();
        pspManager.SetPlayerManager(playerManager);
    }
}
