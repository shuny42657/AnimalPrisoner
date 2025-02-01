using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sync;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using GameLogic.GameSystem;

public class TeamDisplay
{
    TextMeshProUGUI _text;
    Player _localPlayer;
    ITeamable _teamable;

    public TeamDisplay(TextMeshProUGUI text, Player localPlayer, ITeamable teamable)
    {
        _text = text;
        _localPlayer = localPlayer;
        _teamable = teamable;
    }

    public void SetTeamText()
    {
        var team = _teamable.GetTeam(_localPlayer);
        _text.text = ((TeamName)team).ToString();
    }
}
