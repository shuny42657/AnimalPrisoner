using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.Events;

namespace GameLogic.GameSystem
{
    public class ObjectiveManager : MonoBehaviour
    {
        [SerializeField]SerializeInterface<IObjectiveCreator> objectiveCreator;

        List<ObjectiveData> objectives = new();
        [SerializeField] UnityEvent<ObjectiveData> OnNewObjectiveGenerated;
        [SerializeField] UnityEvent<ObjectiveData> OnObjectiveAchieved;

        public void AddNewObjective()
        {
            if(objectives.Count < 2)
            {
                var newObjective = objectiveCreator.Value.CreateObjective();
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
                    OnObjectiveAchieved.Invoke(o);
                    o.UpGradable.UpGrade();
                    objectives.Remove(o);
                    return true;
                }
            }
            return false;
        }
    }
}
