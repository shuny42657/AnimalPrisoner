using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    public class ObjectiveInitializer : MonoBehaviour
    {
        [SerializeField] protected List<ItemName> objectiveItems;
        public ItemName CreateObjective()
        {
            var rand = UnityEngine.Random.Range(0, objectiveItems.Count);
            return objectiveItems[rand];
        }
    }
}
