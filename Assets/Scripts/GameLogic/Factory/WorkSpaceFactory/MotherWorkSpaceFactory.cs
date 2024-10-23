using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using GameLogic.WorkSpace;

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
        [SerializeField] WorkSpaceFactory stonOilCrafter;
        [SerializeField] WorkSpaceFactory woodIronCrafter;
        [SerializeField] WorkSpaceFactory woodOilCrafter;
        [SerializeField] WorkSpaceFactory ironOilCrafter;

        [SerializeField] BaseWorkSpace _stoneMaker;
        [SerializeField] BaseWorkSpace _woodMaker;
        [SerializeField] BaseWorkSpace _ironMaker;
        [SerializeField] BaseWorkSpace _oilMaker;
        [SerializeField] BaseWorkSpace _waterMaker;
        [SerializeField] BaseWorkSpace _riceMaker;

        [SerializeField] BaseWorkSpace _stoneWoodWorkCrafter;

        public GameObject Generate(JobName name, Vector3 position)
        {
            switch (name)
            {
                case JobName.StoneMaker:
                    //return stoneMakerFactory.GenerateItem(position);
                    var newStoneMaker = Instantiate(_stoneMaker, position, Quaternion.identity);
                    newStoneMaker.InitializeWorkSpace();
                    return newStoneMaker.gameObject;
                case JobName.WoodMaker:
                    //return woodMakerFactory.GenerateItem(position);
                    var newWoodMaker = Instantiate(_woodMaker, position, Quaternion.identity);
                    newWoodMaker.InitializeWorkSpace();
                    return newWoodMaker.gameObject;
                case JobName.IronMaker:
                    //return ironMakerFactory.GenerateItem(position);
                    var newIronMaker = Instantiate(_ironMaker, position, Quaternion.identity);
                    newIronMaker.InitializeWorkSpace();
                    return newIronMaker.gameObject;
                case JobName.OilMaker:
                    //return oilMakerFactory.GenerateItem(position);
                    var newOilMaker = Instantiate(_oilMaker, position, Quaternion.identity);
                    newOilMaker.InitializeWorkSpace();
                    return newOilMaker.gameObject;
                case JobName.WaterMaker:
                    //return waterMakerFactory.GenerateItem(position);
                    var newWaterMaker = Instantiate(_waterMaker, position, Quaternion.identity);
                    newWaterMaker.InitializeWorkSpace();
                    return newWaterMaker.gameObject;
                case JobName.RiceMaker:
                    //return riceMakerFactory.GenerateItem(position);
                    var newRiceMaker = Instantiate(_riceMaker, position, Quaternion.identity);
                    newRiceMaker.InitializeWorkSpace();
                    return newRiceMaker.gameObject;
                case JobName.StoneIronCrafter:
                    return stoneIronCrafter.GenerateItem(position);
                case JobName.StoneWoodCrafter:
                    var newStoneWoodCrafter = Instantiate(_stoneWoodWorkCrafter, position, Quaternion.identity);
                    newStoneWoodCrafter.InitializeWorkSpace();
                    return newStoneWoodCrafter.gameObject;
                    //return stoneWoodCrafter.GenerateItem(position);
                case JobName.StoneOilCrafter:
                    return stonOilCrafter.GenerateItem(position);
                case JobName.WoodIronCrafter:
                    return woodIronCrafter.GenerateItem(position);
                case JobName.WoodOilCrafter:
                    return woodOilCrafter.GenerateItem(position);
                case JobName.OilIronCrafter:
                    return ironOilCrafter.GenerateItem(position);
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
