using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sync
{
    public interface IMatchinCallback
    {
        public UnityEvent OnRoomJoined { get; }
    }
}
