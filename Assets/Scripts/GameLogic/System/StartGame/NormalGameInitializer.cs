using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    public class NormalGameInitializer : MonoBehaviour, IGameInitializer
    {
        [SerializeField] RoomParameter roomParameter;
        [SerializeField] Pacer roomParamPacer;
        [SerializeField] Pacer leveledObjCreatorPacer;
        public void InitializeGame()
        {
            roomParameter.FuelComsumeSpeed = 2f;
            roomParameter.DuranilityCosumeSpeed = 1.5f;
            roomParameter.ElectricityConsumeSpeed = 1f;

            roomParamPacer.IsActive = true;
            leveledObjCreatorPacer.IsActive = true;
            //Do everything necessary to start a game
        }
    }
}
