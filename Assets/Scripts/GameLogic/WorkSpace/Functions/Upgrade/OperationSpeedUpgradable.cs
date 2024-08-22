using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class OperationSpeedUpgradable : MonoBehaviour,IUpGradable
    {
        [SerializeField] SerializeInterface<IAutomatable> automatable;
        int level = 0;

        [SerializeField] UpGraderName upGraderName; public UpGraderName UpGraderName { get { return upGraderName; } }

        List<float> opSpeeds = new() { 1f, 1.2f, 1.5f, 1.8f, 2.0f };

        public int Level => throw new System.NotImplementedException();

        public void UpGrade()
        {
            level++;
            automatable.Value.OperationSpeed = opSpeeds[level];
        }
    }
}
