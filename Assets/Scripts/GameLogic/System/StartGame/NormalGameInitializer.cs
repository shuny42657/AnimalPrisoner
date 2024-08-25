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
        [SerializeField] Pacer objectiveCreatorPacer;
            
        public void InitializeGame()
        {

            roomParameter.FuelComsumeSpeed = 2f;
            roomParameter.DuranilityCosumeSpeed = 1.5f;
            roomParameter.ElectricityConsumeSpeed = 1f;
            roomParameter.IsActive = true;

            roomParamPacer.IsActive = true;
            leveledObjCreatorPacer.IsActive = true;
            objectiveCreatorPacer.IsActive = true;
            //Do everything necessary to start a game
        }
    }
}
