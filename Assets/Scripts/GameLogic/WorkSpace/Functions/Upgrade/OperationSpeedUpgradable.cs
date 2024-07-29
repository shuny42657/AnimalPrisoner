using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class OperationSpeedUpgradable : MonoBehaviour,IUpGradable
    {
        [SerializeField] SerializeInterface<IAutomatable> automatable;
        int level = 0;

        List<float> opSpeeds = new() { 1f, 1.2f, 1.5f, 1.8f, 2.0f };
        public void UpGrade()
        {
            level++;
            automatable.Value.OperationSpeed = opSpeeds[level];
        }
    }
}
