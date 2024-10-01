using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using GameLogic.GamePlayer;

public class P_PlayerStatus_View : MonoBehaviour
{
    [SerializeField] GaugeView gaugeView;

    public void SetPlayerStatusCallback(GameObject player)
    {
        var playerStatus = player.transform.GetChild(1).GetComponent<IPlayerStatus>();
        playerStatus.OnEnergyModified.AddListener((rate) => gaugeView.ModifyGauge(rate));
    }
}
