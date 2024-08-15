using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{

    //Attach to a component that does some operation inside Update(),
    //Control its activity (ON / OFF)
    public interface ISwitchable
    {
        public bool IsActive { get; set; }
    }
}
