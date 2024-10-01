using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class WorkSpaceFactory : MonoBehaviour,IFactory<GameObject>
    {
        [SerializeField] GameObject workSpace;
        public GameObject GenerateItem(Vector3 position)
        {
            GameObject newWorkSpace = Instantiate(workSpace, position, Quaternion.identity);
            return newWorkSpace;
        }

        public GameObject GenerateItem(Transform transform)
        {
            GameObject newWorkSpace = Instantiate(workSpace, transform);
            return newWorkSpace;
        }
    }
}
