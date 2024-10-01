using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Data
{
    public class JobDataBase : MonoBehaviour,IDataBase<JobData,JobName>
    {
        [SerializeField] List<JobData> jobData;
        Dictionary<JobName, JobData> jobDict = new();
        private void Awake()
        {
            foreach(var j in jobData)
            {
                jobDict.Add(j.JobName, j);
            }
        }

        public IEnumerable<JobData> GetAllData()
        {
            return jobData;
        }

        public JobData GetData(JobName name)
        {
            return jobDict[name];
        }
    }
}
