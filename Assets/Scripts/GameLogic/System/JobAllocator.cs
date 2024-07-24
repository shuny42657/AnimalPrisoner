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
            var jobCount = System.Enum.GetValues(typeof(WorkSpaceName)).Length;
            foreach(var p in players.Values)
            {
                List<int> jobs = new();
                while(jobs.Count < 4)
                { 
                    var newJob = Random.Range(0, jobCount);
                    if (!jobs.Contains(newJob))
                    {
                        Debug.Log("new job set");
                        jobs.Add(newJob);
                        p.SetJob(jobs.Count - 1, newJob);
                    }
                }
                p.SetJobDetermined(true);
            }
            Debug.Log("Job Set");
        }
    }
}

