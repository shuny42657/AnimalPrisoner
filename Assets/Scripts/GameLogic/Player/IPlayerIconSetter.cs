using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public interface IPlayerIconSetter
{
    public void SetPlayerIcon();
}

public class PlayerColorIconSetter : IPlayerIconSetter
{
    Player _localPlayer;
    List<GameObject> _colorIcons;
    Transform _transform;

    public PlayerColorIconSetter(Player localPlayer, List<GameObject> colorIcons, Transform transform)
    {
        _localPlayer = localPlayer;
        _colorIcons = colorIcons;
        _transform = transform;
    }

    public void SetPlayerIcon()
    {
        var icon = Object.Instantiate(_colorIcons[_localPlayer.ActorNumber - 1], _transform);
        icon.transform.SetAsFirstSibling();
        icon.transform.localPosition = Vector3.zero;
    }
}
