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
        public void AddUpGradable(IUpGradable upgradable);
    }

    public class ObjectiveCreator : MonoBehaviour, IObjectiveCreator
    {
        [SerializeField] protected List<ItemName> objectiveItems;
        [SerializeField] protected List<IUpGradable> upgradables = new();

        IDitribution<int> distribution = new FrozenDistribution();

        public void AddUpGradable(IUpGradable upgradable)
        {
            upgradables.Add(upgradable);
            Debug.Log($"upgradable count : {upgradables.Count}");
        }

        public virtual ObjectiveData CreateObjective()
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
