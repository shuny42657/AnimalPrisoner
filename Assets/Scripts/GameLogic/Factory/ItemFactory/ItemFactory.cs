using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class ItemFactory : MonoBehaviour, IFactory<GameObject>
    {
        [SerializeField] GameObject item;
        public GameObject GenerateItem(Vector3 position)
        {
            GameObject prefab = Instantiate(item, position, Quaternion.identity);
            //IResource grabbable = item.GetComponent<IResource>();
            return prefab;
        }

        public GameObject GenerateItem(Transform transform)
        {
            GameObject prefab = Instantiate(item, transform);
            //IResource grabbable = item.GetComponent<IResource>();
            return prefab;
        }
    }
}
