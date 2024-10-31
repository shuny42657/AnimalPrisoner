using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    
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
