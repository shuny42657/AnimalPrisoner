using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.GameSystem
{
    public class ObjectiveInitializer : MonoBehaviour
    {
        [SerializeField] protected List<ItemName> objectiveItems;
        List<int> _selectedIndex = new();

        public ItemName CreateObjective()
        {
            int rand = 0;
            while (true)
            {
                rand = UnityEngine.Random.Range(0, objectiveItems.Count);
                if (!_selectedIndex.Contains(rand))
                    break;
            }
            return objectiveItems[rand];
        }
    }
}
