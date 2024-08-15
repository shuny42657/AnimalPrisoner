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
            newPlayer.GetComponent<IMovable>().CanMove = true;
            OnPlayerGenerate.Invoke(newPlayer);
            return player;
        }
    }
}
