using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using UnityEngine.Events;
using GameLogic.GameSystem;
using GameLogic.GamePlayer;

namespace GameLogic.WorkSpace
{
    public class BedAutomatable : BaseAutomatable<int>
    {
        public override void InitateOperation()
        {
            IsActive = true;
            OnOperationInitiated.Invoke();
        }
    }
}
