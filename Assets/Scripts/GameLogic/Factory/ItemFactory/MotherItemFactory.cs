using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class MotherItemFactory : MonoBehaviour, IMotherFactory<ItemName, IGrabbable>
    {
        [SerializeField] StoneItemFactory stoneItemFactory;
        [SerializeField] WoodItemFactory woodItemFactory;
        [SerializeField] IronItemFactory ironItemFactory;
        [SerializeField] OilItemFactory oilItemFactory;
        [SerializeField] WaterItemFactory waterItemFactory;
        [SerializeField] RiceItemFactory riceItemFactory;
        [SerializeField] SerializeInterface<IGrabbable> stone;
        public IGrabbable Generate(ItemName name)
        {
            switch (name)
            {
                case ItemName.Stone:
                    stoneItemFactory.GenerateWorkSpace(new Vector3(0f, 1f, 0f));
                    return stone.Value;
                default:
                    return null;
            }
        }
    }
}
