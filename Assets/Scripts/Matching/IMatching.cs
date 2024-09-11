using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Matching
{
    /// <summary>
    /// Written by Shinnosuke
    /// </summary>
    public interface IMatching
    {
        public void ConnectToMasterServer();
        public void RegisterCallback();
        public void StartMatching();
    }
}
