using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    public interface IScoreCounter
    {
        public void AddItem(ItemName itemName);
        public int GetScore();
    }
}
