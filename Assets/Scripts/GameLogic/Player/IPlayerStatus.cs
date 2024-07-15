using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Player
{
    public interface IPlayerStatus
    {
        public int Energy { get; set; }
        public int Hunger { get; set; }
    }

}
