using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public interface ITeamable
{
    public void SetTeam(Player player, int team);
    public int GetTeam(Player player);
}

public interface ITeamInitlaizer
{
    public void InitializeTeam();
}

public enum Team
{
    Alice,
    Bob,
    NoTeam,
}
