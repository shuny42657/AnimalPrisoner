using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sync;
using GameLogic.GamePlayer;
using GameLogic.Map;
using GameLogic.GameSystem;

public class P_PlayerFactory_MatchingManager : MonoBehaviour
{
    [SerializeField] PlayerCustomPropertyCallback callBack;
    [SerializeField] MapBuilder mapBuilder;
    [SerializeField] JobDisplay jobDisplay;

    public void SetJobToCallBack(GameObject player)
    {
        var jobStatus = player.GetComponent<JobStatus>();
        callBack.onComplete.AddListener(() => jobStatus.SetJobs());
        jobStatus.OnJobSet.AddListener((i_jobStatus) => mapBuilder.BuildWorkSpaces(i_jobStatus));
        jobStatus.OnJobSet.AddListener((i_jobStatus) => jobDisplay.DisplayJob(i_jobStatus));
    }
}
