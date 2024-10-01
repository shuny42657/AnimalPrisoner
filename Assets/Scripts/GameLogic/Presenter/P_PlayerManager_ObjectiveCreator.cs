using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;
using GameLogic.GamePlayer;

public class P_PlayerManager_ObjectiveCreator : MonoBehaviour
{
    [SerializeField] SerializeInterface<IObjectiveCreator> objectiveCreator;

    public void SetPlayerUpgradable(GameObject player)
    {
        var playerManager = player.GetComponent<PlayerManager>();
        objectiveCreator.Value.AddUpGradable(playerManager.UpGradable);
    }
}
