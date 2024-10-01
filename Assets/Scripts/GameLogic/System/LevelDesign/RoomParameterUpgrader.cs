using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using Photon.Pun;
using Sync;
using GameLogic.GameSystem;

public class RoomParameterUpgrader : MonoBehaviourPunCallbacks,IUpGradable
{
    [SerializeField] RoomParameter roomParam;
    int level;
    public int Level { get { return level; } }

    [SerializeField] UpGraderName upgraderName;
    public UpGraderName UpGraderName { get { return upgraderName; } }

    [SerializeField] List<float> fuelDecaySpeeds;
    [SerializeField] List<float> durabilityDecaySpeeds;
    [SerializeField] List<float> electricityDecaySpeeds;

    public void UpGrade()
    {
        level = PhotonNetwork.CurrentRoom.GetDecayLevelUp();
        Debug.Log($"Decay Level {level}");
        roomParam.FuelComsumeSpeed = fuelDecaySpeeds[level];
        roomParam.DuranilityCosumeSpeed = durabilityDecaySpeeds[level];
        roomParam.ElectricityConsumeSpeed = electricityDecaySpeeds[level];
    }

    public void IncrementLevel(int level)
    {
        Debug.Log("Decay Level Up");
        PhotonNetwork.CurrentRoom.SetDecayLevelUp(level);
    }
}
