using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
            return player;
        }
    }
}
