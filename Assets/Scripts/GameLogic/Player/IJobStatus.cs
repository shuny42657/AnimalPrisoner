using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public enum JobName
    {
        StoneMaker,
        WoodMaker,
        IronMaker,
        OilMaker,
        WaterMaker,
        RiceMaker,
        StoneWoodCrafter,
        StoneIronCrafter,
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
