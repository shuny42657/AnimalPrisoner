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
        IEnumerableRead<ItemName> _objectiveManager;
        TeamName _team;
        public ObjectiveProgressViewer(
            IGaugeView gaugeView,
            IEnumerableRead<ItemName> objectiveManager,
            TeamName team
            )
        {
            _gaugeView = gaugeView;
            _objectiveManager = objectiveManager;
            _team = team;
        }

        public void UpdateViewer()
        {
            var room = PhotonNetwork.CurrentRoom;
            int init = _objectiveManager.Count;
            int count = 0;
            for (int i = 0; i < init; i++)
            {
                if (room.GetObjective(i, (int)_team) == (int)ItemName.None)
                {
                    count += 1;
                }
            }
            _gaugeView.ModifyGauge((float)count / init);
        }
    }
}
