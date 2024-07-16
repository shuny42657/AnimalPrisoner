using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class StoneItemFactory : MonoBehaviour, IFactory<IGrabbable>
    {
        [SerializeField] IGrabbable stone;
        public IGrabbable GenerateWorkSpace(Vector3 position)
        {
            Instantiate(this.gameObject, position, Quaternion.identity);
            return stone;
        }
    }
}
