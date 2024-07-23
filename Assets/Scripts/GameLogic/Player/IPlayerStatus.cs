using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.GamePlayer
{
    public interface IPlayerStatus
    {
        public UnityEvent<int> OnEnergyModified { get; }
        public UnityEvent<int> OnHungerModified { get; }
        public int Energy { get; set; }
        public int Hunger { get; set; }
    }

}
