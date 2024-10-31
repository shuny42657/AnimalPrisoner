using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Util;

namespace GameLogic.WorkSpace
{
    /// <summary>
    /// 転送系（Teleporter, Receiver)にアタッチするWorkSpace
    /// </summary>
    public class TeleportWorkSpace : WorkSpace
    {
        [SerializeField] SerializeInterface<ITextView<int>> _teleporTextView;
        public ITextView<int> TeleportTextView { get { return _teleporTextView.Value; } }
    }

}

