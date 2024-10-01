using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class SimpleResitrationPlayerTrigger : MonoBehaviour,IPlayerTriggerable
    {
        [SerializeField] UnityEvent onPlayerEnter = new(); public UnityEvent OnPlayerEnter { get { return onPlayerEnter; } }

        [SerializeField] UnityEvent onPlayerExit = new(); public UnityEvent OnPlayerExit { get { return onPlayerExit; } }
    }
}


