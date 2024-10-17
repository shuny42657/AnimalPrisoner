using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic
{
    public enum JobName
    {
        StoneMaker = 0,
        WoodMaker = 1,
        IronMaker = 2,
        OilMaker = 3,
        WaterMaker = 4,
        RiceMaker = 5,
        StoneWoodCrafter = 6,
        StoneIronCrafter = 7,
        StoneOilCrafter = 8,
        WoodIronCrafter = 9,
        WoodOilCrafter = 10,
        OilIronCrafter = 11,
    }
}

namespace GameLogic.GamePlayer
{
    public interface IJobStatus
    {
        public UnityEvent<IJobStatus> OnJobSet { get; }
        public List<JobName> GetAllJobs();
        public void SetJob(JobName job);
        public void SetJobs();
        public void ClearJob();
    }
}
