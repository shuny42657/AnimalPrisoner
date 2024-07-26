using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Sync;
using UnityEngine.Events;

namespace GameLogic.GamePlayer
{
    public class JobStatus : MonoBehaviour,IJobStatus
    {
        List<JobName> jobs  = new();

        public UnityEvent<IJobStatus> OnJobSet = new();
        public List<JobName> GetAllJobs()
        {
            return jobs;
        }

        public void SetJob(JobName job)
        {
            jobs.Add(job);
        }

        public void ClearJob()
        {
            jobs.Clear();
        }

        public void SetJobs()
        {
            var localPlayer = PhotonNetwork.LocalPlayer;
            if (localPlayer.GetJobDetermined())
            {
                for(int i = 0;i < 4;i++)
                {
                    jobs.Add((JobName)localPlayer.GetJob(i));
                }
                Debug.Log($" {jobs.Count} Jobs Set");
                OnJobSet.Invoke(this);
            }
        }
    }
}
