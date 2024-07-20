using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class OilItemFactory : MonoBehaviour, IFactory<IGrabbable>
    {
        [SerializeField] GameObject item;
        public IGrabbable GenerateItem(Vector3 position)
        {
            GameObject prefab = Instantiate(item, position, Quaternion.identity);
            IGrabbable grabbable = item.GetComponent<IGrabbable>();
            return grabbable;
        }
    }
}
