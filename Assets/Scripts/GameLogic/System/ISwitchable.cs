using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// Inplements Turning ON and OFF
    /// Classes with this interface should function only when they are ON.
    /// </summary>
    public interface ISwitchable
    {
        public bool IsActive { get; set; }
    }
}
