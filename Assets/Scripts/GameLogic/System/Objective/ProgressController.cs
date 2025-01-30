using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using Photon.Pun;
using Photon.Realtime;
using Sync;
using UnityEngine.Events;

public interface IProgressController
{
    public void AddProgress(ItemName item);
    public void Reset();
    public int MaxProgress { get; }
    public UnityEvent OnProgressFull { get; }
}

public sealed class SimpleProgressController : IProgressController
{
    Room _currentRoom;
    int _addedValue;
    int _maxProgress;

    UnityEvent _onProgressFull = new(); public UnityEvent OnProgressFull
    {
        get { return _onProgressFull; }
    }

    public int MaxProgress { get { return _maxProgress; } }

    public SimpleProgressController(int addedValue, int maxProgress)
    {
        _currentRoom = PhotonNetwork.CurrentRoom;
        _addedValue = addedValue;
        _maxProgress = maxProgress;
    }

    public void AddProgress(ItemName item)
    {
        TeamName team = AlphaOrBeta(item);
        int currentProgress = _currentRoom.GetProgress((int)team);
        _currentRoom.SetProgress((int)team, currentProgress + _addedValue);
    }

    public void Reset()
    {
        _currentRoom.SetProgress((int)TeamName.Alpha, 0);
        _currentRoom.SetProgress((int)TeamName.Beta, 0);
    }

    TeamName AlphaOrBeta(ItemName item)
    {
        for(int i = 0; i < 3;i++)
        {
            if(_currentRoom.GetObjective(i, (int)TeamName.Alpha) == (int)item)
            {
                return TeamName.Alpha;
            }
        }
        return TeamName.Beta;
    }
}
