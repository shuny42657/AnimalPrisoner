using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    public class ObjectivePacer : MonoBehaviour, ISwitchable
    {
        public bool IsActive { get; set; }

        [SerializeField] ObjectiveManager objectiveManager;

        public void FillObjective()
        {
            objectiveManager.AddNewObjective();
        }
    }
}
