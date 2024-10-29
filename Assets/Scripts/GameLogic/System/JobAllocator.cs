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

    public class MainJobAllocator : IJobAllocator
    {
        public void AllocateJob()
        {
            var players = PhotonNetwork.CurrentRoom.Players;
            var jobCount = System.Enum.GetValues(typeof(JobName)).Length;
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

    public class SimpleJobAllocator : IJobAllocator
    {
        public void AllocateJob()
        {
            var players = PhotonNetwork.CurrentRoom.Players;
            foreach(var p in players.Values)
            {
                p.SetJob(0, (int)JobName.StoneMaker);
                p.SetJob(1, (int)JobName.WoodMaker);
                p.SetJob(2, (int)JobName.StoneWoodCrafter);
                p.SetJob(3, (int)JobName.StoneIronCrafter);
            }
            foreach (var p in players.Values)
            {
                p.SetJobDetermined(true);
            }
            Debug.Log("Job Set");
        }
    }
}

