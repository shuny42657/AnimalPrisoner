using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class MotherItemFactory : MonoBehaviour, IMotherFactory<ItemName, IResource>
    {
        [SerializeField] StoneItemFactory stoneItemFactory;
        [SerializeField] WoodItemFactory woodItemFactory;
        [SerializeField] IronItemFactory ironItemFactory;
        [SerializeField] OilItemFactory oilItemFactory;
        [SerializeField] WaterItemFactory waterItemFactory;
        [SerializeField] RiceItemFactory riceItemFactory;
        public IResource Generate(ItemName name, Vector3 position)
        {
            IResource grabbable = null;
            switch (name)
            {
                case ItemName.Stone:
                    grabbable = stoneItemFactory.GenerateItem(position);
                    break;
                case ItemName.Wood:
                    grabbable = woodItemFactory.GenerateItem(position);
                    break;
                case ItemName.Iron:
                    grabbable = ironItemFactory.GenerateItem(position);
                    break;
                case ItemName.Oil:
                    grabbable = oilItemFactory.GenerateItem(position);
                    break;
                case ItemName.Water:
                    grabbable = waterItemFactory.GenerateItem(position);
                    break;
                case ItemName.Rice:
                    grabbable = riceItemFactory.GenerateItem(position);
                    break;
                default:
                    break;
            }
            return grabbable;
        }
    }
}
