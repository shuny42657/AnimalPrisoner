using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class WorkSpeedUpgradable : MonoBehaviour,IUpGradable
    {
        [SerializeField] SerializeInterface<IWork> work;
        int level = 0;

        [SerializeField] UpGraderName upGraderName; public UpGraderName UpGraderName { get { return upGraderName; } }

        List<float> workSpeeds = new() { 1f, 1.2f, 1.5f, 1.8f, 2.0f };

        public int Level => throw new System.NotImplementedException();

        public void UpGrade()
        {
            level++;
            work.Value.WorkSpeed = workSpeeds[level];
        }
    }
}
