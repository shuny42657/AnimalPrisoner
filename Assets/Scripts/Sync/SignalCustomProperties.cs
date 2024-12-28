using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Globalization;
using ExitGames.Client.Photon;

namespace Sync
{
    public enum SignalPropertyKey
    {
        none,
        from_player_1,
        from_player_2,
        from_player_3,
        from_player_4,
    }
    public static class SignalCustomProperties
    {
        private static Hashtable propsToSet = new();
        public static string[] signalKeys = new string[4] { SignalPropertyKey.from_player_1.ToString(), SignalPropertyKey.from_player_2.ToString(), SignalPropertyKey.from_player_3.ToString(), SignalPropertyKey.from_player_4.ToString() };
        public static int ReceiveSignal(this Player player, int index)
        {
            if (index == 0)
                Debug.Log("Signal Set to None");
            return (player.CustomProperties[signalKeys[index - 1]] is int itemId) ? itemId : 0;
        }
        public static void SendSignal(this Player player, int index, int item)
        {
            propsToSet[signalKeys[index - 1]] = item;
            player.SetCustomProperties(propsToSet);
            propsToSet.Clear();
        }
    }
}
