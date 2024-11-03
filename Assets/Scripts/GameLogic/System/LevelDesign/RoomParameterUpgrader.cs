using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using Photon.Pun;
using Sync;
using GameLogic.GameSystem;

public class RoomParameterUpgrader : IUpGradable
{
    [SerializeField] RoomParameter _roomParam;
    int level;
    public int Level { get { return level; } }

    [SerializeField] UpGraderName upgraderName;
    public UpGraderName UpGraderName { get { return upgraderName; } }

    [SerializeField] List<float> _fuelDecaySpeeds;
    [SerializeField] List<float> _durabilityDecaySpeeds;
    [SerializeField] List<float> _electricityDecaySpeeds;

    public RoomParameterUpgrader(
        RoomParameter roomParam,
        List<float> fuelDecaySpeeds,
        List<float> durabilityDecaySpeeds,
        List<float> electricityDecaySpeeds
        )
    {
        _roomParam = roomParam;
        _fuelDecaySpeeds = fuelDecaySpeeds;
        _durabilityDecaySpeeds = durabilityDecaySpeeds;
        _electricityDecaySpeeds = electricityDecaySpeeds;
    }

    public void UpGrade()
    {
        level = PhotonNetwork.CurrentRoom.GetDecayLevelUp();
        Debug.Log($"Decay Level {level}");
        _roomParam.FuelComsumeSpeed = _fuelDecaySpeeds[level];
        _roomParam.DuranilityCosumeSpeed = _durabilityDecaySpeeds[level];
        _roomParam.ElectricityConsumeSpeed = _electricityDecaySpeeds[level];
    }

    public void IncrementLevel(int level)
    {
        Debug.Log("Decay Level Up");
        PhotonNetwork.CurrentRoom.SetDecayLevelUp(level);
    }
}
