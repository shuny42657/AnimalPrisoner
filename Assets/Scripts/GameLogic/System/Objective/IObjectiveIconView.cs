using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using GameLogic.GameSystem;

/// <summary>
/// Show icon of an object(s) that are set as objectives.
/// </summary>
public interface IObjectiveIconView
{
    public void ShowObjectiveIcon();
}

public class LogObjectiveIconView : IObjectiveIconView
{
    IEnumerableRead<ItemName> _objectivesRead;
    TeamName _team;

    public LogObjectiveIconView(IEnumerableRead<ItemName> objectivesRead, TeamName team)
    {
        _objectivesRead = objectivesRead;
        _team = team;
    }

    public void ShowObjectiveIcon()
    {
        foreach(var item in _objectivesRead.GetAllItems())
        {
            Debug.Log($"{_team} Objective : {item}");
        }
    }
}