using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sync;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using GameLogic.GameSystem;
using UnityEngine.UI;

public interface ITeamDisplay
{
    public void DisplayTeam();
}
public class TeamDisplay : ITeamDisplay
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

    public void DisplayTeam()
    {
        var team = _teamable.GetTeam(_localPlayer);
        _text.text = ((TeamName)team).ToString();
    }
}

public class TeamIconDisPlay : ITeamDisplay
{
    Player _localPlayer;
    Sprite _alphaIcon;
    Sprite _betaIcon;
    Image _image;
    ITeamable _teamable;

    public TeamIconDisPlay(Image image, Sprite alphaIcon, Sprite betaIcon, Player localPlayer,ITeamable teamable)
    {
        _localPlayer = localPlayer;
        _alphaIcon = alphaIcon;
        _betaIcon = betaIcon;
        _image = image;
        _teamable = teamable;
    }

    public void DisplayTeam()
    {
        if (_teamable.GetTeam(_localPlayer) == (int)TeamName.Alpha)
        {
            _image.sprite = _alphaIcon;
        }
        else
        {
            _image.sprite = _betaIcon;
        }
    }
}
