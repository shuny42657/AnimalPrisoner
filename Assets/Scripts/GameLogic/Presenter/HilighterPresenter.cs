using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using Util;

public class HilighterPresenter : MonoBehaviour
{
    [SerializeField] SerializeInterface<IPlayerTriggerable> playerTrigger;
    [SerializeField] SerializeInterface<IHilightVisualizer> hilighter;
    // Start is called before the first frame update
    void Awake()
    {
        playerTrigger.Value.OnPlayerEnter.AddListener(() => hilighter.Value.Hilight(true));
        playerTrigger.Value.OnPlayerExit.AddListener(() => hilighter.Value.Hilight(false));
    }
}
