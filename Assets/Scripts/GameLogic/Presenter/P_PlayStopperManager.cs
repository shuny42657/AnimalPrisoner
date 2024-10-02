using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using GameLogic.GamePlayer;

public class P_PlayStopperManager : MonoBehaviour
{
    [SerializeField] RoomParameter roomParam;
    public void Set(GameObject player)
    {
        var playerManager = player.GetComponent<PlayerManager>();
        var playStopper = new PlayStopper(playerManager);

        roomParam.OnParamDead += () => playStopper.StopPlaying()　　;
    }
}
