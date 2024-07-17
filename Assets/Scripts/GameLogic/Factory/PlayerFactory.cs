using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class PlayerFactory : MonoBehaviour,IPlayerFactory
    {
        [SerializeField] GameObject player;
        public GameObject GeneratePlayer(Vector3 position)
        {
            var newPlayer = Instantiate(player,position,Quaternion.identity);
            return player;
        }
    }
}
