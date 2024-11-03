using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public interface IObjectiveManager
    {
        public void AddNewObjective();
        public bool ObjectiveAchieved(ItemName receivedItem);
    }


    public class ObjectiveManager : IObjectiveManager
    {
        IObjectiveCreator _objectiveCreator;

        List<ObjectiveData> objectives = new();
        public UnityEvent<ObjectiveData> OnNewObjectiveGenerated = new();
        public UnityEvent<ObjectiveData> OnObjectiveAchieved = new();

        public ObjectiveManager(IObjectiveCreator objectiveCreator)
        {
            _objectiveCreator = objectiveCreator;
        }

        public void AddNewObjective()
        {
            Debug.Log("objective added");
            if(objectives.Count < 2)
            {
                var newObjective = _objectiveCreator.CreateObjective();
                objectives.Add(newObjective);
                OnNewObjectiveGenerated.Invoke(newObjective);
            }
        }

        public bool ObjectiveAchieved(ItemName receivedItem)
        {
            foreach(var o in objectives)
            {
                if(o.CraftItem == receivedItem)
                {
                    o.UpGradable.UpGrade();
                    objectives.Remove(o);
                    OnObjectiveAchieved.Invoke(o);
                    return true;
                }
            }
            return false;

        }
    }
}
