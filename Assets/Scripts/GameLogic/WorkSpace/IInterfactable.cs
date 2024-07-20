using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    //OnTriggerEnter/Exitでの処理を登録しておくコールバック。（プレイヤーが接触した床の色が変わるなど）
    public interface IInteractable
    {
        public UnityEvent OnEnter { get;}
        public UnityEvent OnExit { get; }
    }
}
