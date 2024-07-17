using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class StoneItemFactory : MonoBehaviour, IFactory<IGrabbable>
    {
        [SerializeField] SerializeInterface<IGrabbable> stone;
        [SerializeField] GameObject stoneWorkSpace;
        public IGrabbable GenerateWorkSpace(Vector3 position)
        {
            Instantiate(stoneWorkSpace, position, Quaternion.identity);
            return stone.Value;
        }
    }
}
