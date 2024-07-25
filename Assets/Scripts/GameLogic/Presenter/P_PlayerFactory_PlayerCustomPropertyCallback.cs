using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sync;
using GameLogic.GamePlayer;
using GameLogic.Map;

public class P_PlayerFactory_MatchingManager : MonoBehaviour
{
    [SerializeField] PlayerCustomPropertyCallback callBack;
    [SerializeField] MapBuilder mapBuilder;

    public void SetJobToCallBack(GameObject player)
    {
        var jobStatus = player.GetComponent<JobStatus>();
        callBack.onComplete.AddListener(() => jobStatus.SetJobs());
        jobStatus.OnJobSet.AddListener((i_jobStatus) => mapBuilder.BuildWorkSpaces(i_jobStatus));
    }
}
