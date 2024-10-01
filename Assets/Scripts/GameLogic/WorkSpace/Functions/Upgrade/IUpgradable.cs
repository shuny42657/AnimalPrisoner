using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public interface IUpGradable
    {
        public void UpGrade();
        public int Level { get; }
        public UpGraderName UpGraderName { get; }
    }

    public enum UpGraderName
    {
        StoneMaker,
        WoodMaker,
        IronMaker,
        OilMaker,
        WaterMaker,
        RiceMaker,
        StoneWoodCrafter,
        StoneIronCrafter,
        StoneOilCrafter,
        WoodIronCrafter,
        WoodOilCrafter,
        IronOilCrafter,
        PlayerSpeed,
    }
}
