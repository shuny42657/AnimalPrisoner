using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using System.Linq;
using System;

public class TeamInfo : ITeamable
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

    List<Team> oneToThree = new() { Team.Alice, Team.Bob, Team.Bob, Team.Bob };
    List<Team> twoToTwo = new() { Team.Alice, Team.Alice, Team.Bob, Team.Bob };
    List<Team> threeToOne = new() { Team.Alice, Team.Alice, Team.Alice, Team.Bob };

    public TeamInitializer(ITeamable teamable)
    {
        _teamable = teamable;
    }

    public void InitializeTeam()
    {
        var rand = UnityEngine.Random.Range(0, 3);
        List<Team> list = new();
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
