using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Setting info about the player (mainly shown in the upper left corner of the game scene)
/// </summary>
public interface IPlayerInfoSetter
{
    public void SetPlayerInfo();
}

public class PlayerInfoSetter : IPlayerInfoSetter
{
    ITeamDisplay _teamDisplay;
    IPlayerIconSetter _colorIconSetter;

    public PlayerInfoSetter(ITeamDisplay teamDisplay, IPlayerIconSetter colorIconSetter)
    {
        _teamDisplay = teamDisplay;
        _colorIconSetter = colorIconSetter;
    }

    public void SetPlayerInfo()
    {
        _teamDisplay.DisplayTeam();
        _colorIconSetter.SetPlayerIcon();
    }
}
