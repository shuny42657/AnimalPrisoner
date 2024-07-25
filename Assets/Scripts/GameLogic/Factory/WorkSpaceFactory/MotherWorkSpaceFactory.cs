using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameLogic.Factory
{
    public class MotherWorkSpaceFactory : MonoBehaviour,IMotherFactory<JobName,GameObject>
    {
        [SerializeField] WorkSpaceFactory stoneMakerFactory;
        [SerializeField] WorkSpaceFactory woodMakerFactory;
        [SerializeField] WorkSpaceFactory ironMakerFactory;
        [SerializeField] WorkSpaceFactory oilMakerFactory;
        [SerializeField] WorkSpaceFactory waterMakerFactory;
        [SerializeField] WorkSpaceFactory riceMakerFactory;
        [SerializeField] WorkSpaceFactory stoneWoodCrafter;
        [SerializeField] WorkSpaceFactory stoneIronCrafter;

        public GameObject Generate(JobName name, Vector3 position)
        {
            switch (name)
            {
                case JobName.StoneMaker:
                    return stoneMakerFactory.GenerateItem(position);
                case JobName.WoodMaker:
                    return woodMakerFactory.GenerateItem(position);
                case JobName.IronMaker:
                    return ironMakerFactory.GenerateItem(position);
                case JobName.OilMaker:
                    return oilMakerFactory.GenerateItem(position);
                case JobName.WaterMaker:
                    return waterMakerFactory.GenerateItem(position);
                case JobName.RiceMaker:
                    return riceMakerFactory.GenerateItem(position);
                case JobName.StoneIronCrafter:
                    return stoneIronCrafter.GenerateItem(position);
                case JobName.StoneWoodCrafter:
                    return stoneWoodCrafter.GenerateItem(position);
                default:
                    return null;
            }
        }

        public GameObject Generate(JobName name, Transform parentTransform)
        {
            switch (name)
            {
                case JobName.StoneMaker:
                    return stoneMakerFactory.GenerateItem(parentTransform);
                case JobName.WoodMaker:
                    return woodMakerFactory.GenerateItem(parentTransform);
                case JobName.IronMaker:
                    return ironMakerFactory.GenerateItem(parentTransform);
                case JobName.OilMaker:
                    return oilMakerFactory.GenerateItem(parentTransform);
                case JobName.WaterMaker:
                    return waterMakerFactory.GenerateItem(parentTransform);
                case JobName.RiceMaker:
                    return riceMakerFactory.GenerateItem(parentTransform);
                case JobName.StoneIronCrafter:
                    return stoneIronCrafter.GenerateItem(parentTransform);
                case JobName.StoneWoodCrafter:
                    return stoneWoodCrafter.GenerateItem(parentTransform);
                default:
                    return null;
            }
        }
    }
}
