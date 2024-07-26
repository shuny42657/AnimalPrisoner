using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}

namespace GameLogic.GamePlayer
{
    public interface IJobStatus
    {
        public List<JobName> GetAllJobs();
        public void SetJob(JobName job);
        public void ClearJob();
    }
}
