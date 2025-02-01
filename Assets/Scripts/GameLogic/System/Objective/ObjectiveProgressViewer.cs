using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using UI;
using Util;
using Photon.Pun;
using Sync;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// Written by Shinnosuke (2025/1/2)
    /// </summary>
    public class ObjectiveProgressViewer
    {
        IGaugeView _gaugeView;
        int _maxProgress;

        public ObjectiveProgressViewer(
            IGaugeView gaugeView,
            int maxProgress
            )
        {
            _gaugeView = gaugeView;
            _maxProgress = maxProgress;
        }

        public void UpdateViewer(int val)
        {
            Debug.Log("Viewer Updated");
            /*var room = PhotonNetwork.CurrentRoom;
            int init = _objectiveManager.Count;
            int count = 0;
            for (int i = 0; i < init; i++)
            {
                if (room.GetObjective(i, (int)_team) == (int)ItemName.None)
                {
                    count += 1;
                }
            }*/
            _gaugeView.ModifyGauge((float)val / _maxProgress);
        }
    }
}
