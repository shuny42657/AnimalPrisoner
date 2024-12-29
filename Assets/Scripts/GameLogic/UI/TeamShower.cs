using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Photon.Realtime;
using Photon.Pun;

public class TeamShower
{
    Player _localPlayer;
    ITextAnimation _textAnimation;
    ITeamable _teamable;

    public TeamShower(ITextAnimation textAnimation,ITeamable teamable)
    {
        _localPlayer = PhotonNetwork.LocalPlayer;
        _textAnimation = textAnimation;
        _teamable = teamable;
    }

    public async UniTask ShowTeam()
    {
        await _textAnimation.ShowTextAnimation(_teamable.GetTeam(_localPlayer).ToString());
    }
}
