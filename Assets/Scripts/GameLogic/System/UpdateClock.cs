using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// Component for calling methods at every Update frame
    /// (All classes that have a method to be executed inside Update() must be registered to this class)
    /// </summary>
    public class UpdateClock : MonoBehaviour,ISwitchable,IClock
    {
        List<ITick> ticks = new();

        public bool IsActive { get; set; }

        public void AddTick(ITick tick)
        {
            ticks.Add(tick);
        }

        // Update is called once per frame
        void Update()
        {
            if (IsActive)
            {
                foreach(var tick in ticks)
                {
                    tick.Tick();
                }
            }
        }
    }
}
