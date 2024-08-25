using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameLogic.GamePlayer;

namespace GameLogic.Factory
{
    public class PlayerFactory : MonoBehaviour,IPlayerFactory
    {
        [SerializeField] GameObject player;

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
