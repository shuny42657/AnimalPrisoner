using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using Util;
using System;

namespace GameLogic.GameSystem
{
    //Create Objective
    public interface IObjectiveCreator
    {
        public ObjectiveData CreateObjective();
    }

    public class ObjectiveCreator : MonoBehaviour, IObjectiveCreator
    {
        [SerializeField] List<ItemName> objectiveItems;
        List<IUpGradable> upgradables = new();

        IDitribution<int> distribution;

        public void AddUpGradable(IUpGradable upgradable)
        {
            upgradables.Add(upgradable);
        }

        public ObjectiveData CreateObjective()
        {
            //upgradable
            System.Random random = new();
            var id = distribution.Sample(random);
            var upgradable = upgradables[id];

            //craftItem
            var rand = UnityEngine.Random.Range(0, objectiveItems.Count);
            var craftItem = objectiveItems[rand];

            ObjectiveData newObjective = new(craftItem, upgradable);
            return newObjective;
        }
    }
}
