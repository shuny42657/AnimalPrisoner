using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameLogic.Factory
{
    public interface IPlayerFactory
    {
        public GameObject GeneratePlayer(Vector3 position);
    }
}
