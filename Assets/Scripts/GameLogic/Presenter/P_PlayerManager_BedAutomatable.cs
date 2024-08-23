using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using GameLogic.WorkSpace;

public class P_PlayerManager_BedAutomatable : MonoBehaviour
{
    [SerializeField] BedAutomatable bedAutomatable;
    public void Set(GameObject player)
    {
        var playerManager = player.GetComponent<PlayerManager>();
        bedAutomatable.onOperationFinish.AddListener((val) => FinishOperation(playerManager));
        bedAutomatable.OnOperationInitiated.AddListener(() => InitiateOperation(playerManager));
    }

    public void InitiateOperation(PlayerManager playerManager)
    {
        playerManager.SetCanMove(false);
    }

    public void FinishOperation(PlayerManager playerManager)
    {
        playerManager.SetCanMove(true);
        playerManager.PlayerStatus.Energy = playerManager.PlayerStatus.MaxEnergy;
    }
}
