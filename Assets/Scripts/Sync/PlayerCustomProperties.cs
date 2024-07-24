using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Globalization;
using ExitGames.Client.Photon;

namespace Sync
{
    public enum RoomPropertyKey
    {
        mcplt,
    }

    public enum PlayerPropertyKey
    {
        jd,
        first_job,
        second_job,
        third_job,
        fourth_job,
        from_player_1,
        from_player_2,
        from_player_3,
        from_player_4,
    }

    public static class RoomCustomProperties
    {
        public static Hashtable propsToSet = new();
        public static bool GetMatchComplete(this Room room)
        {
            return (room.CustomProperties[RoomPropertyKey.mcplt.ToString()] is bool score) && score;
        }

        public static void SetMatchComplete(this Room room, bool yes)
        {
            propsToSet[RoomPropertyKey.mcplt.ToString()] = yes;
            room.SetCustomProperties(propsToSet);
            propsToSet.Clear();
        }
    }

    public static class PlayerCustomProperties
    {
        private static Hashtable propsToSet = new();
        public static string jobDeterminedKey = "jd";
        public static string[] jobKeys = new string[4] { PlayerPropertyKey.first_job.ToString(), PlayerPropertyKey.second_job.ToString(), PlayerPropertyKey.third_job.ToString(), PlayerPropertyKey.fourth_job.ToString() };
        public static string[] sendItemKeys = new string[4] { PlayerPropertyKey.from_player_1.ToString(), PlayerPropertyKey.from_player_2.ToString(), PlayerPropertyKey.from_player_3.ToString(), PlayerPropertyKey.from_player_4.ToString() };
        public static int GetJob(this Player player,int index)
        {
            return (player.CustomProperties[jobKeys[index]] is int job) ? job : 1 ;
        }

        public static void SetJob(this Player player, int index, int job)
        {
            propsToSet[jobKeys[index]] = job;
            player.SetCustomProperties(propsToSet);
            propsToSet.Clear();
        }

        public static bool GetJobDetermined(this Player player)
        {
            return (player.CustomProperties[PlayerPropertyKey.jd.ToString()] is bool jd) && jd;
        }

        public static void SetJobDetermined(this Player player, bool yes)
        {
            propsToSet[PlayerPropertyKey.jd.ToString()] = yes;
            player.SetCustomProperties(propsToSet);
            propsToSet.Clear();
        }

        public static int GetSentItem(this Player player,int index)
        {
            return (player.CustomProperties[sendItemKeys[index - 1]] is int itemId) ? itemId : 0;
        }

        public static void SetSendItem(this Player player,int index, int item)
        {
            propsToSet[sendItemKeys[index-1]] = item;
            player.SetCustomProperties(propsToSet);
            propsToSet.Clear();
        }
    }
}
