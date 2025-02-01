using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Sync;
using GameLogic.GameSystem;

public class PlayerWin : IGetter<bool>
{
    int _maxProgress;
    Player _localPlayer;
    ITeamable _teamable;

    public PlayerWin(int maxProgress, Player localPlayer, ITeamable teamable)
    {
        _maxProgress = maxProgress;
        _localPlayer = localPlayer;
        _teamable = teamable;
    }

    public bool Value
    {
        get
        {
            if (!PhotonNetwork.CurrentRoom.GetGameOver())
            {
                return false;
            }
            else
            {
                if(PhotonNetwork.CurrentRoom.GetProgress((int)TeamName.Alpha) == _maxProgress)
                {
                    return (TeamName)_teamable.GetTeam(_localPlayer) == TeamName.Alpha;
                }
                else if(PhotonNetwork.CurrentRoom.GetProgress((int)TeamName.Beta) == _maxProgress)
                {
                    return (TeamName)_teamable.GetTeam(_localPlayer) == TeamName.Beta;
                }
            }
            return false;
        }
    }
}