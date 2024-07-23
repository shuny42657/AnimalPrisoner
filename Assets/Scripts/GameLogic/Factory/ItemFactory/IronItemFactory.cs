using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameLogic.Factory
{
    public class IronItemFactory : MonoBehaviour, IFactory<IResource>
    {
        [SerializeField] GameObject item;
        public IResource GenerateItem(Vector3 position)
        {
            GameObject prefab = Instantiate(item, position, Quaternion.identity);
            IResource grabbable = item.GetComponent<IResource>();
            return grabbable;
        }

        public IResource GenerateItem(Transform transform)
        {
            GameObject prefab = Instantiate(item, transform);
            IResource grabbable = item.GetComponent<IResource>();
            return grabbable;
        }
    }
}
