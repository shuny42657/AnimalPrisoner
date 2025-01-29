using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using System.Linq;
using System;
using GameLogic.GameSystem;

public class TeamSetter : ITeamable
{
    private Hashtable _propsToSet = new();
    string _teamKey = "team";

    public Team GetTeam(Player player)
    {
        return (player.CustomProperties[_teamKey] is int id) ? (Team)id : Team.Alice;
    }

    public void SetTeam(Player player,int team)
    {
        _propsToSet[_teamKey] = team;
        player.SetCustomProperties(_propsToSet);
        _propsToSet.Clear();
    }
}

public class TeamInitializer : ITeamInitlaizer
{
    ITeamable _teamable;

    List<TeamName> oneToThree = new() { TeamName.Alpha, TeamName.Beta, TeamName.Alpha, TeamName.Beta };
    List<TeamName> twoToTwo = new() { TeamName.Alpha, TeamName.Alpha, TeamName.Beta, TeamName.Beta};
    List<TeamName> threeToOne = new() { TeamName.Alpha, TeamName.Alpha, TeamName.Alpha, TeamName.Beta };

    public TeamInitializer(ITeamable teamable)
    {
        _teamable = teamable;
    }

    public void InitializeTeam()
    {
        var rand = UnityEngine.Random.Range(0, 3);
        List<TeamName> list = new();
        switch (rand)
        {
            case 0:
                list = oneToThree;
                break;
            case 1:
                list = twoToTwo;
                break;
            case 2:
                list = threeToOne;
                break;
        }

        list = list.OrderBy(a => Guid.NewGuid()).ToList();

        var players = PhotonNetwork.PlayerList;

        for(int i = 0; i < players.Length; i++)
        {
            var player = players[i];
            _teamable.SetTeam(player, (int)(list[i]));
        }
    }
}
