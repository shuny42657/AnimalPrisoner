using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PlayerInfoViewer : MonoBehaviour
    {
        /// <summary>
        /// Written by Shinnosuke (2024/11/7)
        /// </summary>
        [SerializeField] int actorNumber; public int ActorNumber { get { return actorNumber; } set { actorNumber = value; } }
        [SerializeField] ImageSetter playerIcon; public ImageSetter PlayerIcon { get { return playerIcon; } }
        [SerializeField] ImageSetter playerNameplate; public ImageSetter PlayerNameplate { get { return playerNameplate; } }
        [SerializeField] TextSetter playerName; public TextSetter PlayerName { get { return playerName; } }
    }
}
