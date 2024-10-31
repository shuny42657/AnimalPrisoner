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
    /// <summary>
    /// Creates Makers and Crafter
    /// </summary>
    public class MakerCrafterFactory : MonoBehaviour,IMotherFactory<JobName,WorkSpace.WorkSpace>
    {
        [SerializeField] WorkSpace.WorkSpace _stoneMaker;
        [SerializeField] WorkSpace.WorkSpace _woodMaker;
        [SerializeField] WorkSpace.WorkSpace _ironMaker;
        [SerializeField] WorkSpace.WorkSpace _oilMaker;
        [SerializeField] WorkSpace.WorkSpace _waterMaker;
        [SerializeField] WorkSpace.WorkSpace _riceMaker;

        [SerializeField] WorkSpace.WorkSpace _stoneWoodCrafter;
        [SerializeField] WorkSpace.WorkSpace _stoneIronCrafter;
        [SerializeField] WorkSpace.WorkSpace _stoneOilCrafter;
        [SerializeField] WorkSpace.WorkSpace _woodIronCrafter;
        [SerializeField] WorkSpace.WorkSpace _woodOilCrafter;
        [SerializeField] WorkSpace.WorkSpace _ironOilCrafter;

        [SerializeField] WorkSpace.WorkSpace _submissionWorkSpace;

        [SerializeField] KeyDownController _e_keyDownController;
        [SerializeField] KeyDownController _f_keyDownController;
        [SerializeField] KeyHoldController _q_keyHoldController;


        IPlayer _player;
        public void SetPlayer(IPlayer player)
        {
            _player = player;
        }

        [SerializeField] UpdateClock _updateClock;

        /// <summary>
        /// Creates a Maker or Crafter based on the JobName
        /// </summary>
        /// <param name="name">JobName corresponding to a Maker or Crafter to be created</param>
        /// <param name="position">where to put the created maker or crafter</param>
        /// <returns>WorkSpace.WorkSpace</returns>
        public WorkSpace.WorkSpace Generate(JobName name, Vector3 position)
        {
            switch (name)
            {
                case JobName.StoneMaker:
                    var newStoneMaker = Instantiate(_stoneMaker, position, Quaternion.identity);
                    newStoneMaker.SetWorkSpaceManager(new MakerWorkSpaceManagerFactory(_player, ItemName.Stone,UpGraderName.StoneMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newStoneMaker));
                    return newStoneMaker;
                case JobName.WoodMaker:
                    var newWoodMaker = Instantiate(_woodMaker, position, Quaternion.identity);
                    newWoodMaker.SetWorkSpaceManager(new MakerWorkSpaceManagerFactory(_player, ItemName.Wood,UpGraderName.WoodMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newWoodMaker));
                    return newWoodMaker;
                case JobName.IronMaker:
                    var newIronMaker = Instantiate(_ironMaker, position, Quaternion.identity);
                    newIronMaker.SetWorkSpaceManager(new MakerWorkSpaceManagerFactory(_player, ItemName.Iron,UpGraderName.IronMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newIronMaker));
                    return newIronMaker;
                case JobName.OilMaker:
                    var newOilMaker = Instantiate(_oilMaker, position, Quaternion.identity);
                    newOilMaker.SetWorkSpaceManager(new MakerWorkSpaceManagerFactory(_player, ItemName.Oil,UpGraderName.OilMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newOilMaker));
                    return newOilMaker;
                case JobName.WaterMaker:
                    var newWaterMaker = Instantiate(_waterMaker, position, Quaternion.identity);
                    newWaterMaker.SetWorkSpaceManager(new MakerWorkSpaceManagerFactory(_player, ItemName.Water,UpGraderName.WaterMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newWaterMaker));
                    return newWaterMaker;
                case JobName.RiceMaker:
                    var newRiceMaker = Instantiate(_riceMaker, position, Quaternion.identity);
                    newRiceMaker.SetWorkSpaceManager(new MakerWorkSpaceManagerFactory(_player, ItemName.Rice,UpGraderName.RiceMaker, _e_keyDownController, _q_keyHoldController).GenerateWorkSpaceController(newRiceMaker));
                    return newRiceMaker;
                case JobName.StoneIronCrafter:
                    var newStoneIronCrafter = Instantiate(_stoneIronCrafter, position, Quaternion.identity);
                    newStoneIronCrafter.SetWorkSpaceManager(new CrafterWorkSpaceManagerFacotry(_player, _updateClock, ItemName.Stone, ItemName.Iron,UpGraderName.StoneIronCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newStoneIronCrafter));
                    return newStoneIronCrafter;
                case JobName.StoneWoodCrafter:
                    var newStoneWoodCrafter = Instantiate(_stoneWoodCrafter, position, Quaternion.identity);
                    newStoneWoodCrafter.SetWorkSpaceManager(new CrafterWorkSpaceManagerFacotry(_player, _updateClock, ItemName.Stone, ItemName.Wood,UpGraderName.StoneWoodCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newStoneWoodCrafter));
                    return newStoneWoodCrafter;
                case JobName.StoneOilCrafter:
                    var newStoneOilCrafter = Instantiate(_stoneOilCrafter, position, Quaternion.identity);
                    newStoneOilCrafter.SetWorkSpaceManager(new CrafterWorkSpaceManagerFacotry(_player, _updateClock, ItemName.Stone, ItemName.Oil,UpGraderName.StoneOilCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newStoneOilCrafter));
                    return newStoneOilCrafter;
                case JobName.WoodIronCrafter:
                    var newWoodIronCrafter = Instantiate(_woodIronCrafter, position, Quaternion.identity);
                    newWoodIronCrafter.SetWorkSpaceManager(new CrafterWorkSpaceManagerFacotry(_player, _updateClock, ItemName.Wood, ItemName.Iron,UpGraderName.WoodIronCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newWoodIronCrafter));
                    return newWoodIronCrafter;
                case JobName.WoodOilCrafter:
                    var newWoodOilCrafter = Instantiate(_woodOilCrafter, position, Quaternion.identity);
                    newWoodOilCrafter.SetWorkSpaceManager(new CrafterWorkSpaceManagerFacotry(_player, _updateClock, ItemName.Wood, ItemName.Oil,UpGraderName.WoodOilCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newWoodOilCrafter));
                    return newWoodOilCrafter;
                case JobName.OilIronCrafter:
                    var newOilIronCrafter = Instantiate(_ironOilCrafter, position, Quaternion.identity);
                    newOilIronCrafter.SetWorkSpaceManager(new CrafterWorkSpaceManagerFacotry(_player, _updateClock, ItemName.Oil, ItemName.Iron,UpGraderName.IronOilCrafter, _e_keyDownController, _f_keyDownController).GenerateWorkSpaceController(newOilIronCrafter));
                    return newOilIronCrafter;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Not used.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentTransform"></param>
        /// <returns></returns>
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
