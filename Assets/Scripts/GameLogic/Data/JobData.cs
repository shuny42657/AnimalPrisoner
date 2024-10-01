using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic;


[CreateAssetMenu(fileName = "JobData", menuName = "ScriptableObjects/JobData", order = 1)]
public class JobData : ScriptableObject
{
    [SerializeField] JobName jobName; public JobName JobName { get { return jobName; } }
    [SerializeField] Sprite sourceImage; public Sprite SourceImage { get { return sourceImage; } }
}
