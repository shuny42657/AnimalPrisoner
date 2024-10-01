using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    //Executes a set of methods that are necessary to set up a game.
    public interface IGameInitializer
    {
        public void InitializeGame();
    }
}
