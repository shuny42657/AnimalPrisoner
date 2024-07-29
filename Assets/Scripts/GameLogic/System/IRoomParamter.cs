using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public interface IRoomStatus
    {
        public UnityEvent<float> OnFuelModified { get; }
        public UnityEvent<float> OnDurabilityModified { get; }
        public UnityEvent<float> OnElectricityModified { get;}

        public float Fuel { get; }
        public float Durability { get; }
        public float Electricity { get; }
    }
}
