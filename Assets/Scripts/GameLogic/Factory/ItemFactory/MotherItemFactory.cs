using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameLogic.Factory
{
    public class MotherItemFactory : MonoBehaviour, IMotherFactory<ItemName, GameObject>
    {
        [SerializeField] ItemFactory stoneItemFactory;
        [SerializeField] ItemFactory woodItemFactory;
        [SerializeField] ItemFactory ironItemFactory;
        [SerializeField] ItemFactory oilItemFactory;
        [SerializeField] ItemFactory waterItemFactory;
        [SerializeField] ItemFactory riceItemFactory;
        [SerializeField] ItemFactory stone1Wood1Factory;
        [SerializeField] ItemFactory stone1Iron1Factory;

        public GameObject Generate(ItemName name, Vector3 position)
        {
            GameObject grabbable = null;
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
                case ItemName.Stone1Wood1:
                    grabbable = stone1Wood1Factory.GenerateItem(position);
                    break;
                case ItemName.Stone1Iron1:
                    grabbable = stone1Iron1Factory.GenerateItem(position);
                    break;
                default:
                    break;
            }
            return grabbable;
        }

        public GameObject Generate(ItemName name, Transform transform)
        {
            switch (name)
            {
                case ItemName.Stone:
                    return stoneItemFactory.GenerateItem(transform);
                case ItemName.Wood:
                    return woodItemFactory.GenerateItem(transform);
                case ItemName.Iron:
                    return ironItemFactory.GenerateItem(transform);
                case ItemName.Oil:
                    return oilItemFactory.GenerateItem(transform);
                case ItemName.Water:
                    return waterItemFactory.GenerateItem(transform);
                case ItemName.Rice:
                    return riceItemFactory.GenerateItem(transform);
                case ItemName.Stone1Wood1:
                    return stone1Wood1Factory.GenerateItem(transform);
                case ItemName.Stone1Iron1:
                    return stone1Iron1Factory.GenerateItem(transform);
                default:
                    return null;
            }
        }
    }
}
