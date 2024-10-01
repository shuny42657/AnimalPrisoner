using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Sync;
using GameLogic.WorkSpace;

namespace GameLogic.GameSystem
{
    public class RoomParameterLevelDesigner : MonoBehaviourPunCallbacks,ISwitchable
    {
        [SerializeField] List<float> fuelDecaySpeeds;
        [SerializeField] List<float> durabilityDecaySpeeds;
        [SerializeField] List<float> electricityDecaySpeeds;
        [SerializeField] RoomParameter roomParam;

        [SerializeField] List<float> phaseDuration;
        int level = 0; public int Level { get { return level; } }
        float currentTime;
        [SerializeField] bool isActive;
        public bool IsActive { get { return isActive; } set { isActive = value; } }

        // Update is called once per frame
        void Update()
        {
            if (IsActive && PhotonNetwork.IsMasterClient)
            {
                currentTime += Time.deltaTime;
                if(level < phaseDuration.Count && currentTime > phaseDuration[level])
                {
                    currentTime = 0;
                    level++;
                    PhotonNetwork.CurrentRoom.SetDecayLevelUp(level);
                }
            }
        }

        public void UpGrade()
        {
            level = PhotonNetwork.CurrentRoom.GetDecayLevelUp();
            roomParam.FuelComsumeSpeed = fuelDecaySpeeds[level];
            roomParam.DuranilityCosumeSpeed = durabilityDecaySpeeds[level];
            roomParam.ElectricityConsumeSpeed = electricityDecaySpeeds[level];
        }

        public void SetDecayLevelAtStart()
        {
            PhotonNetwork.CurrentRoom.SetDecayLevelUp(level);
        }

        public void IncrementDecayLevel()
        {
            Debug.Log("Decay Level Up");
            roomParam.FuelComsumeSpeed = fuelDecaySpeeds[level];
            roomParam.DuranilityCosumeSpeed = durabilityDecaySpeeds[level];
            roomParam.ElectricityConsumeSpeed = electricityDecaySpeeds[level];
            
        }
    }
}
