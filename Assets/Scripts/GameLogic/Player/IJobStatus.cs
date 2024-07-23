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
    }
}

namespace GameLogic.GamePlayer
{
    public interface IJobStatus
    {
        public List<JobName> GetAllJobs();
        public void SetJob(JobName job);
    }
}
