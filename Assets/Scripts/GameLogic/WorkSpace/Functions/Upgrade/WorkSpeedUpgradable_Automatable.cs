using System.Collections;
using System.Collections.Generic;
using Codice.CM.Client.Differences;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class WorkSpeedUpgradable_Automatable : MonoBehaviour,IUpGradable
    {
        [SerializeField] SerializeInterface<IAutomatable> automatable;

        int level = 0;
        public int Level { get { return level; } }

        [SerializeField] UpGraderName upGraderName;
        public UpGraderName UpGraderName { get { return upGraderName; } }

        List<float> workSpeeds = new() { 1f, 1.2f, 1.5f, 1.8f, 2.0f };
        public void UpGrade()
        {
            level++;
            automatable.Value.OperationSpeed = workSpeeds[level];
        }
    }
}
