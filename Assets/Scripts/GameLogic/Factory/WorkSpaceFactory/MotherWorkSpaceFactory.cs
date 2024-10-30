using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using GameLogic.WorkSpace;
using Util;
using GameLogic.GamePlayer;
using GameLogic.GameSystem;

namespace GameLogic.Factory
{
    public class MotherWorkSpaceFactory : MonoBehaviour,IMotherFactory<JobName,WorkSpace.WorkSpace>
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

        [SerializeField] WorkSpace.WorkSpace _stoneMaker;
        [SerializeField] WorkSpace.WorkSpace _woodMaker;
        [SerializeField] WorkSpace.WorkSpace _ironMaker;
        [SerializeField] WorkSpace.WorkSpace _oilMaker;
        [SerializeField] WorkSpace.WorkSpace _waterMaker;
        [SerializeField] WorkSpace.WorkSpace _riceMaker;

        //[SerializeField] BaseWorkSpace _stoneMaker;
        //[SerializeField] BaseWorkSpace _woodMaker;
        //[SerializeField] BaseWorkSpace _ironMaker;
        //[SerializeField] BaseWorkSpace _oilMaker;
        //[SerializeField] BaseWorkSpace _waterMaker;
        //[SerializeField] BaseWorkSpace _riceMaker;

        [SerializeField] WorkSpace.WorkSpace _stoneWoodCrafter;
        [SerializeField] WorkSpace.WorkSpace _stoneIronCrafter;
        [SerializeField] WorkSpace.WorkSpace _stoneOilCrafter;
        [SerializeField] WorkSpace.WorkSpace _woodIronCrafter;
        [SerializeField] WorkSpace.WorkSpace _woodOilCrafter;
        [SerializeField] WorkSpace.WorkSpace _ironOilCrafter;
        //[SerializeField] BaseWorkSpace _stoneWoodWorkCrafter;
        //[SerializeField] BaseWorkSpace _stoneIronCrafter;
        //[SerializeField] BaseWorkSpace _stoneOilCrafter;
        //[SerializeField] BaseWorkSpace _woodIronCrafter;
        //[SerializeField] BaseWorkSpace _woodOilCrafter;
        //[SerializeField] BaseWorkSpace _ironOilCrafter;

        [SerializeField] WorkSpace.WorkSpace _submissionWorkSpace;

        [SerializeField] KeyDownController _e_keyDownController;
        [SerializeField] KeyDownController _f_keyDownController;
        [SerializeField] KeyHoldController _q_keyHoldController;


        IPlayer _player;
        public void SetPlayer(IPlayer player) { _player = player; }

        [SerializeField] UpdateClock _updateClock;

        public WorkSpace.WorkSpace Generate(JobName name, Vector3 position)
        {
            switch (name)
            {
                case JobName.StoneMaker:
                    //return stoneMakerFactory.GenerateItem(position);
                    var newStoneMaker = Instantiate(_stoneMaker, position, Quaternion.identity);
                    newStoneMaker.SetWorkSpaceManager(new MakerWorkSpaceControllerFactory(_player, ItemName.Stone,UpGraderName.StoneMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newStoneMaker));
                    return newStoneMaker;
                case JobName.WoodMaker:
                    //return woodMakerFactory.GenerateItem(position);
                    var newWoodMaker = Instantiate(_woodMaker, position, Quaternion.identity);
                    newWoodMaker.SetWorkSpaceManager(new MakerWorkSpaceControllerFactory(_player, ItemName.Wood,UpGraderName.WoodMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newWoodMaker));
                    //newWoodMaker.InitializeWorkSpace();
                    return newWoodMaker;
                case JobName.IronMaker:
                    //return ironMakerFactory.GenerateItem(position);
                    var newIronMaker = Instantiate(_ironMaker, position, Quaternion.identity);
                    newIronMaker.SetWorkSpaceManager(new MakerWorkSpaceControllerFactory(_player, ItemName.Iron,UpGraderName.IronMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newIronMaker));
                    //newIronMaker.InitializeWorkSpace();
                    return newIronMaker;
                case JobName.OilMaker:
                    //return oilMakerFactory.GenerateItem(position);
                    var newOilMaker = Instantiate(_oilMaker, position, Quaternion.identity);
                    newOilMaker.SetWorkSpaceManager(new MakerWorkSpaceControllerFactory(_player, ItemName.Oil,UpGraderName.OilMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newOilMaker));
                    //newOilMaker.InitializeWorkSpace();
                    return newOilMaker;
                case JobName.WaterMaker:
                    //return waterMakerFactory.GenerateItem(position);
                    var newWaterMaker = Instantiate(_waterMaker, position, Quaternion.identity);
                    newWaterMaker.SetWorkSpaceManager(new MakerWorkSpaceControllerFactory(_player, ItemName.Water,UpGraderName.WaterMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newWaterMaker));
                    //newWaterMaker.InitializeWorkSpace();
                    return newWaterMaker;
                case JobName.RiceMaker:
                    //return riceMakerFactory.GenerateItem(position);
                    var newRiceMaker = Instantiate(_riceMaker, position, Quaternion.identity);
                    newRiceMaker.SetWorkSpaceManager(new MakerWorkSpaceControllerFactory(_player, ItemName.Rice,UpGraderName.RiceMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newRiceMaker));
                    //newRiceMaker.InitializeWorkSpace();
                    return newRiceMaker;
                case JobName.StoneIronCrafter:
                    var newStoneIronCrafter = Instantiate(_stoneIronCrafter, position, Quaternion.identity);
                    newStoneIronCrafter.SetWorkSpaceManager(new CrafterWorkSpaceControllerFacotry(_player, _updateClock, ItemName.Stone, ItemName.Iron,UpGraderName.StoneIronCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newStoneIronCrafter));
                    //return newStoneIronCrafter;
                    return null;
                    //return stoneIronCrafter.GenerateItem(position);
                case JobName.StoneWoodCrafter:
                    var newStoneWoodCrafter = Instantiate(_stoneWoodCrafter, position, Quaternion.identity);
                    newStoneWoodCrafter.SetWorkSpaceManager(new CrafterWorkSpaceControllerFacotry(_player, _updateClock, ItemName.Stone, ItemName.Wood,UpGraderName.StoneWoodCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newStoneWoodCrafter));
                    //newStoneWoodCrafter.InitializeWorkSpace();
                    //return newStoneWoodCrafter;
                    return null;
                //return stoneWoodCrafter.GenerateItem(position);
                case JobName.StoneOilCrafter:
                    var newStoneOilCrafter = Instantiate(_stoneOilCrafter, position, Quaternion.identity);
                    newStoneOilCrafter.SetWorkSpaceManager(new CrafterWorkSpaceControllerFacotry(_player, _updateClock, ItemName.Stone, ItemName.Oil,UpGraderName.StoneOilCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newStoneOilCrafter));
                    //return newStoneOilCrafter;
                    return null;
                //return stonOilCrafter.GenerateItem(position);
                case JobName.WoodIronCrafter:
                    var newWoodIronCrafter = Instantiate(_woodIronCrafter, position, Quaternion.identity);
                    newWoodIronCrafter.SetWorkSpaceManager(new CrafterWorkSpaceControllerFacotry(_player, _updateClock, ItemName.Wood, ItemName.Iron,UpGraderName.WoodIronCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newWoodIronCrafter));
                    //return newWoodIronCrafter.gameObject;
                    return null;
                //return woodIronCrafter.GenerateItem(position);
                case JobName.WoodOilCrafter:
                    var newWoodOilCrafter = Instantiate(_woodOilCrafter, position, Quaternion.identity);
                    newWoodOilCrafter.SetWorkSpaceManager(new CrafterWorkSpaceControllerFacotry(_player, _updateClock, ItemName.Wood, ItemName.Oil,UpGraderName.WoodOilCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newWoodOilCrafter));
                    //return newWoodOilCrafter.gameObject;
                    return null;
                //return woodOilCrafter.GenerateItem(position);
                case JobName.OilIronCrafter:
                    var newOilIronCrafter = Instantiate(_ironOilCrafter, position, Quaternion.identity);
                    newOilIronCrafter.SetWorkSpaceManager(new CrafterWorkSpaceControllerFacotry(_player, _updateClock, ItemName.Oil, ItemName.Iron,UpGraderName.IronOilCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newOilIronCrafter));
                    //return newOilIronCrafter.gameObject;
                    return null;
                //return ironOilCrafter.GenerateItem(position);
                default:
                    return null;
            }
        }

        public WorkSpace.WorkSpace Generate(JobName name, Transform parentTransform)
        {
            switch (name)
            {
                case JobName.StoneMaker:
                    //return stoneMakerFactory.GenerateItem(parentTransform);
                    return null; ;
                case JobName.WoodMaker:
                    //return woodMakerFactory.GenerateItem(parentTransform);
                    return null;
                case JobName.IronMaker:
                    //return ironMakerFactory.GenerateItem(parentTransform);
                    return null;
                case JobName.OilMaker:
                    //return oilMakerFactory.GenerateItem(parentTransform);
                    return null;
                case JobName.WaterMaker:
                    //return waterMakerFactory.GenerateItem(parentTransform);
                    return null;
                case JobName.RiceMaker:
                    //return riceMakerFactory.GenerateItem(parentTransform);
                    return null;
                case JobName.StoneIronCrafter:
                    //return stoneIronCrafter.GenerateItem(parentTransform);
                    return null;
                case JobName.StoneWoodCrafter:
                    //return stoneWoodCrafter.GenerateItem(parentTransform);
                    return null;
                default:
                    return null;
            }
        }
    }
}
