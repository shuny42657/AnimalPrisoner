using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public interface IInteractable
    {
        public UnityEvent OnEnter { get;}
        public UnityEvent OnExit { get; }
    }
}
