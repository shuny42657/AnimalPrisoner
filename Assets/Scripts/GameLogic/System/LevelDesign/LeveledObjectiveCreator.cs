using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using Util;

namespace GameLogic.GameSystem
{
    public class LeveledObjectiveCreator : ObjectiveCreator,IUpGradable
    {
        List<int> weights = new() { 1,1,1,1,1,1};

        int prev_level = 1;
        int level = 1;
        public int Level { get { return level; } }

        List<int> LoadCategorical()
        {
            if(prev_level == level)
            {
                return weights;
            }
            else
            {
                weights.Clear();
                switch (level)
                {
                    case 1:
                        for(int i = 0;i < 6; i++)
                        {
                            weights.Add(1);
                        }
                        return weights;
                    case 2:
                        for(int i = 0;i < 12; i++)
                        {
                            weights.Add(i < 6 ? 1 : 2);
                        }
                        return weights;
                    case 3:
                        for(int i = 0; i < 18;i++)
                        {
                            if(i < 6) { weights.Add(1); }
                            else if(i < 12) { weights.Add(2); }
                            else { weights.Add(3); }
                        }
                        return weights;
                    default:
                        return weights;
                }
            }
        }
        public override ObjectiveData CreateObjective()
        {
            var random = new System.Random();
            var weights = LoadCategorical();
            var dist = new CategoricalDistribution(weights).Sample(random);

            var craftItem = objectiveItems[dist];

            var up_id = Random.Range(0, upgradables.Count);
            var upgradable = upgradables[up_id];

            ObjectiveData newObjective = new(craftItem, upgradable);
            return newObjective;
        }

        public void UpGrade()
        {
            level++;
        }
    }
}
