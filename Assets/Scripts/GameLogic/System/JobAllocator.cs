using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using GameLogic.WorkSpace;
using Sync;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// Assign 4 jobs to each player. 
    /// </summary>
    public interface IJobAllocator
    {
        public void AllocateJob();
    }

    /// <summary>
    /// Assign 4 jobs that are passed to the contructor
    /// This class is for Debug (See the commented line at 
    /// </summary>
    public class FixedJobAllocater : IJobAllocator
    {
        JobName _firstJob;
        JobName _secondJob;
        JobName _thirdJob;
        JobName _fourthJob;

        public FixedJobAllocater(
            JobName firstJob,
        JobName secondJob,
        JobName thirdJob,
        JobName fourthJob
            )
        {
            _firstJob = firstJob;
            _secondJob = secondJob;
            _thirdJob = thirdJob;
            _fourthJob = fourthJob;
        }
        public void AllocateJob()
        {
            var players = PhotonNetwork.CurrentRoom.Players;

            foreach(var p in players.Values)
            {
                p.SetJob(0, (int)_firstJob);
                p.SetJob(1, (int)_secondJob);
                p.SetJob(2, (int)_thirdJob);
                p.SetJob(3, (int)_fourthJob);
            }

            foreach (var p in players.Values)
            {
                p.SetJobDetermined(true);
            }
        }
    }

    /// <summary>
    /// Assign Jobs to each player.
    /// For each player, randomly pick 4 jobs out of 12 candidates.
    /// </summary>
    public class MainJobAllocator : IJobAllocator
    {
        public void AllocateJob()
        {
            var players = PhotonNetwork.CurrentRoom.Players;
            List<JobName> jobNamePool = new();
            for(int i = 0;i < 16; i++)
            {
                if(i < 12)
                {
                    jobNamePool.Add((JobName)i);
                }
                else
                {
                    var rand = Random.Range(0, 12);
                    jobNamePool.Add((JobName)rand);
                }
            }

            Debug.Log($"job pool {jobNamePool.Count}");
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

