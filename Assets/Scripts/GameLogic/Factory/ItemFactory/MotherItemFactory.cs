using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class MotherItemFactory : MonoBehaviour, IMotherFactory<ItemName, IGrabbable>
    {
        [SerializeField] StoneItemFactory stoneItemFactory;
        [SerializeField] IGrabbable stone;
        public IGrabbable Generate(ItemName name)
        {
            if (name == ItemName.Stone)
            {
                stoneItemFactory.GenerateWorkSpace(new Vector3(0f, 1f, 0f));
            }
            return stone;
        }
    }
}
