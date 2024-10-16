using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameLogic.GamePlayer;
using GameLogic.GameSystem;
using Sync;
using GameLogic.Map;
using UI;
using GameLogic.WorkSpace;

namespace GameLogic.Factory
{
    public class PlayerFactory : MonoBehaviour,IPlayerFactory
    {
        [SerializeField] GameObject player;

        /*[SerializeField] PlayerCustomPropertyCallback _callback;
        [SerializeField] MapBuilder _mapBuilder;
        [SerializeField] JobDisplay _jobDisplay;
        [SerializeField] GaugeView _gaugeView;
        [SerializeField] ObjectiveCreator _objectiveCreator;
        [SerializeField] BedAutomatable _bedAutomatable;*/
        //PlayStopper

        public UnityEvent<GameObject> OnPlayerGenerate = new();
        public GameObject GeneratePlayer(Vector3 position)
        {
            var newPlayer = Instantiate(player,position,Quaternion.identity);
            OnPlayerGenerate.Invoke(newPlayer);
            var playerManager = newPlayer.GetComponent<PlayerManager>();
            playerManager.PlayerStatus.Energy = playerManager.PlayerStatus.MaxEnergy;
            newPlayer.GetComponent<IMovable>().CanMove = true;
            return player;
        }
    }
}
