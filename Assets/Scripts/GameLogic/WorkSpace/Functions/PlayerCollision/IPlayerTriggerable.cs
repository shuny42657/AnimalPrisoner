using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public interface IPlayerTriggerable
    {
        public UnityEvent OnPlayerEnter { get; }
        public UnityEvent OnPlayerExit { get; }
    }
}
