using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    public class GameStartManager : MonoBehaviour
    {
        [SerializeField] SerializeInterface<IGameInitializer> gameInitializer;

        public void InitializeGame()
        {
            gameInitializer.Value.InitializeGame();
        }
    }
}
