using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.GamePlayer
{
    public interface IPlayerStatus
    {
        public UnityEvent<float> OnEnergyModified { get; }
        public UnityEvent<float> OnHungerModified { get; }
        public float Energy { get; set; }
        public float Hunger { get; set; }
        public float MaxEnergy { get; }
    }
}
