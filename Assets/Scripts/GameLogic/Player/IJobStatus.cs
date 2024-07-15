using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JobName
{
    StoneMaker,
    WoodMaker,
    IronMaker,
    OilMaker,
    WaterMaker,
    RiceMaker,
}
public interface IJobStatus
{
    public List<JobName> GetAllJobs();
    public void SetJob(JobName job);
}
