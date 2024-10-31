using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public class WorkSpeedUpgradable : IUpGradable
    {
        IWork _work;
        int level = 0;

        public WorkSpeedUpgradable(IWork work,List<float> workSpeeds, UpGraderName upGraderName)
        {
            _work = work;
            _upGraderName = upGraderName;
            _workSpeeds = workSpeeds;
        }
        [SerializeField] UpGraderName _upGraderName; public UpGraderName UpGraderName { get { return _upGraderName; } }

        List<float> _workSpeeds = new() { 1f, 1.2f, 1.5f, 1.8f, 2.0f };

        public int Level => throw new System.NotImplementedException();

        public void UpGrade()
        {
            level++;
            _work.WorkSpeed = _workSpeeds[level];
        }
    }

    public class NullUpGradable : IUpGradable
    {
        int _level;
        public int Level { get { return _level; } }

        UpGraderName _upGraderName;
        public UpGraderName UpGraderName { get { return _upGraderName; } }

        public void UpGrade()
        {

        }
    }

    public class AutomateSpeedUpGradable : IUpGradable
    {
        IAutomatable _automatable;

        int _level = 0;
        public int Level { get { return _level; } }

        [SerializeField] UpGraderName _upGraderName;
        public UpGraderName UpGraderName { get { return _upGraderName; } }

        List<float> _workSpeeds = new() { 1f, 1.2f, 1.5f, 1.8f, 2.0f };

        public AutomateSpeedUpGradable(
            IAutomatable automatable,
            UpGraderName upGraderName,
            List<float> workSpeeds
            )
        {
            _automatable = automatable;
            _upGraderName = upGraderName;
            _workSpeeds = workSpeeds;
        }

        public void UpGrade()
        {
            _level++;
            _automatable.OperationSpeed = _workSpeeds[_level];
        }
    }
}
