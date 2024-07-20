using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class RiceItemFactory : MonoBehaviour, IFactory<IResource>
    {
        [SerializeField] GameObject item;
        public IResource GenerateItem(Vector3 position)
        {
            GameObject prefab = Instantiate(item, position, Quaternion.identity);
            IResource grabbable = item.GetComponent<IResource>();
            return grabbable;
        }
    }
}
