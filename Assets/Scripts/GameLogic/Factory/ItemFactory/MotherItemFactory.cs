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
        [SerializeField] ItemFactory stone1Oil1Factory;
        [SerializeField] ItemFactory wood1Iron1Factory;
        [SerializeField] ItemFactory wood1Oil1Factory;
        [SerializeField] ItemFactory iron1Oil1Factory;
        [SerializeField] ItemFactory stone1Wood2Factory;
        [SerializeField] ItemFactory stone1Iron2Factory;
        [SerializeField] ItemFactory stone1Oil2Factory;
        [SerializeField] ItemFactory wood1Iron2Factory;
        [SerializeField] ItemFactory wood1Oil2Factory;
        [SerializeField] ItemFactory iron1Oil2Factory;
        [SerializeField] ItemFactory stone2Wood1Factory;
        [SerializeField] ItemFactory stone2Iron1Factory;
        [SerializeField] ItemFactory stone2Oil1Factory;
        [SerializeField] ItemFactory wood2Iron1Factory;
        [SerializeField] ItemFactory wood2Oil1Factory;
        [SerializeField] ItemFactory iron2Oil1Factory;
        [SerializeField] ItemFactory stone2Wood2Factory;
        [SerializeField] ItemFactory stone2Iron2Factory;
        [SerializeField] ItemFactory stone2Oil2Factory;
        [SerializeField] ItemFactory wood2Iron2Factory;
        [SerializeField] ItemFactory wood2Oil2Factory;
        [SerializeField] ItemFactory iron2Oil2Factory;


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
                case ItemName.Stone1Oil1:
                    grabbable = stone1Oil1Factory.GenerateItem(position);
                    break;
                case ItemName.Wood1Iron1:
                    grabbable = wood1Iron1Factory.GenerateItem(position);
                    break;
                case ItemName.Wood1Oil1:
                    grabbable = wood1Oil1Factory.GenerateItem(position);
                    break;
                case ItemName.Iron1Oil1:
                    grabbable = iron1Oil1Factory.GenerateItem(position);
                    break;
                case ItemName.Stone1Wood2:
                    grabbable = stone1Wood2Factory.GenerateItem(position);
                    break;
                case ItemName.Stone2Wood1:
                    grabbable = stone2Wood1Factory.GenerateItem(position);
                    break;
                case ItemName.Stone2Wood2:
                    grabbable = stone2Wood2Factory.GenerateItem(position);
                    break;
                case ItemName.Stone1Iron2:
                    grabbable = stone1Wood2Factory.GenerateItem(position);
                    break;
                case ItemName.Stone2Iron1:
                    grabbable = stone2Iron1Factory.GenerateItem(position);
                    break;
                case ItemName.Stone2Iron2:
                    grabbable = stone2Iron2Factory.GenerateItem(position);
                    break;
                case ItemName.Stone1Oil2:
                    grabbable = stone1Oil2Factory.GenerateItem(position);
                    break;
                case ItemName.Stone2Oil1:
                    grabbable = stone2Oil1Factory.GenerateItem(position);
                    break;
                case ItemName.Stone2Oil2:
                    grabbable = stone2Oil2Factory.GenerateItem(position);
                    break;
                case ItemName.Wood1Iron2:
                    grabbable = wood1Iron2Factory.GenerateItem(position);
                    break;
                case ItemName.Wood2Iron1:
                    grabbable = wood2Iron1Factory.GenerateItem(position);
                    break;
                case ItemName.Wood2Iron2:
                    grabbable = wood2Iron2Factory.GenerateItem(position);
                    break;
                case ItemName.Wood1Oil2:
                    grabbable = wood1Oil2Factory.GenerateItem(position);
                    break;
                case ItemName.Wood2Oil1:
                    grabbable = wood2Oil1Factory.GenerateItem(position);
                    break;
                case ItemName.Wood2Oil2:
                    grabbable = wood2Oil2Factory.GenerateItem(position);
                    break;
                case ItemName.Iron1Oil2:
                    grabbable = iron1Oil2Factory.GenerateItem(position);
                    break;
                case ItemName.Iron2Oil1:
                    grabbable = iron2Oil1Factory.GenerateItem(position);
                    break;
                case ItemName.Iron2Oil2:
                    grabbable = iron2Oil2Factory.GenerateItem(position);
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
                case ItemName.Stone1Oil1:
                    return stone1Oil1Factory.GenerateItem(transform);
                
                case ItemName.Wood1Iron1:
                    return wood1Iron1Factory.GenerateItem(transform);
                    
                case ItemName.Wood1Oil1:
                    return  wood1Oil1Factory.GenerateItem(transform);
                    
                case ItemName.Iron1Oil1:
                    return iron1Oil1Factory.GenerateItem(transform);
                    
                case ItemName.Stone1Wood2:
                    return stone1Wood2Factory.GenerateItem(transform);
                    
                case ItemName.Stone2Wood1:
                    return stone2Wood1Factory.GenerateItem(transform);
                    
                case ItemName.Stone2Wood2:
                    return stone2Wood2Factory.GenerateItem(transform);
                    
                case ItemName.Stone1Iron2:
                    return  stone1Wood2Factory.GenerateItem(transform);
                    
                case ItemName.Stone2Iron1:
                    return stone2Iron1Factory.GenerateItem(transform);
                    
                case ItemName.Stone2Iron2:
                    return stone2Iron2Factory.GenerateItem(transform);
                    
                case ItemName.Stone1Oil2:
                    return stone1Oil2Factory.GenerateItem(transform);
                    
                case ItemName.Stone2Oil1:
                    return stone2Oil1Factory.GenerateItem(transform);
                    
                case ItemName.Stone2Oil2:
                    return  stone2Oil2Factory.GenerateItem(transform);
                    
                case ItemName.Wood1Iron2:
                    return wood1Iron2Factory.GenerateItem(transform);
                    
                case ItemName.Wood2Iron1:
                    return  wood2Iron1Factory.GenerateItem(transform);
                    
                case ItemName.Wood2Iron2:
                    return wood2Iron2Factory.GenerateItem(transform);
                    
                case ItemName.Wood1Oil2:
                    return wood1Oil2Factory.GenerateItem(transform);
                    
                case ItemName.Wood2Oil1:
                    return wood2Oil1Factory.GenerateItem(transform);
                    
                case ItemName.Wood2Oil2:
                    return wood2Oil2Factory.GenerateItem(transform);
                    
                case ItemName.Iron1Oil2:
                    return iron1Oil2Factory.GenerateItem(transform);
                    
                case ItemName.Iron2Oil1:
                    return iron2Oil1Factory.GenerateItem(transform);
                    
                case ItemName.Iron2Oil2:
                    return iron2Oil2Factory.GenerateItem(transform);
                    
                default:
                    return null;
            }
        }
    }
}
