using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using GameLogic.GamePlayer;

public class P_PlayStopperManager : MonoBehaviour
{
    [SerializeField] RoomParameter roomParam;
    [SerializeField] Pacer _roomParamPacer;
    [SerializeField] Pacer _leveledObjCreatorPacer;
    [SerializeField] Pacer _objectiveCreatorPacer;
    public void Set(GameObject player)
    {
        var playerManager = player.GetComponent<PlayerManager>();
        var playStopper = new PlayStopper(playerManager, _roomParamPacer, _leveledObjCreatorPacer, _objectiveCreatorPacer); ;

        roomParam.OnParamDead += () => playStopper.StopPlaying();
    }
}
