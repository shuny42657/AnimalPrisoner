using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using GameLogic.WorkSpace;
using Sync;

namespace GameLogic.GameSystem
{
    public interface IJobAllocator
    {
        public void AllocateJob();
    }

    public class JobAllocator : IJobAllocator
    {
        public void AllocateJob()
        {
            var players = PhotonNetwork.CurrentRoom.Players;
            var jobCount = System.Enum.GetValues(typeof(JobName)).Length;
            foreach(var p in players.Values)
            {
                List<int> jobs = new();
                Debug.Log($"Player : {p.ActorNumber}");
                while(jobs.Count < 4)
                { 
                    var newJob = Random.Range(0, jobCount);
                    if (!jobs.Contains(newJob))
                    {
                        Debug.Log($"new job set{newJob}");
                        jobs.Add(newJob);
                        p.SetJob(jobs.Count - 1, newJob);
                    }
                }
            }
            foreach(var p in players.Values)
            {
                p.SetJobDetermined(true);
            }
            Debug.Log("Job Set");
        }
    }

    public class MainJobAllocator : IJobAllocator
    {
        public void AllocateJob()
        {
            var players = PhotonNetwork.CurrentRoom.Players;
            var jobCount = System.Enum.GetValues(typeof(JobName)).Length;
            List<JobName> jobNamePool = new();
            for(int i = 0;i < 12; i++)
            {
                jobNamePool.Add((JobName)i);
            }

            foreach(var p in players.Values)
            {
                List<int> jobs = new();
                while(jobs.Count < 4)
                {
                    var newJobIndex = Random.Range(0, jobNamePool.Count);
                    var newJob = jobNamePool[newJobIndex];
                    jobs.Add((int)newJob);
                    p.SetJob(jobs.Count - 1, (int)newJob);
                    jobNamePool.RemoveAt(newJobIndex);
                }
            }
            foreach(var p in players.Values)
            {
                p.SetJobDetermined(true);
            }
            Debug.Log("Job Set");
        }
    }
}

