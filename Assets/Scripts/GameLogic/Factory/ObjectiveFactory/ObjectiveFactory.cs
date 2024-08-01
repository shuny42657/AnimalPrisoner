using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using GameLogic.Data;
using GameLogic.GameSystem;


namespace GameLogic.Factory
{
    public class ObjectiveFactory : MonoBehaviour
    {
        [SerializeField] ObjectiveViewer objectiveViewerPrefab;
        [SerializeField] ItemDataBase itemDataBase;
        [SerializeField] JobDataBase jobDataBase;

        Dictionary<ObjectiveData, ObjectiveViewer> objectiveViewerDict = new();
        public ObjectiveViewer Generate(Transform parent, ObjectiveData objectiveData)
        {
            var newObjective = Instantiate(objectiveViewerPrefab, parent);
            objectiveViewerDict.Add(objectiveData, newObjective);
            return newObjective;
        }

        public void DeleteViewer(ObjectiveData objectiveData)
        {
            if (objectiveViewerDict.ContainsKey(objectiveData))
            {
                Destroy(objectiveViewerDict[objectiveData].gameObject);
                objectiveViewerDict.Remove(objectiveData);
            }
        }

    }
}
