using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using GameLogic.Data;
using GameLogic.GameSystem;


namespace GameLogic.Factory
{
    public class ObjectiveViewerFactory : MonoBehaviour
    {
        [SerializeField] ObjectiveViewer objectiveViewerPrefab;
        [SerializeField] ItemDataBase itemDataBase;
        [SerializeField] JobDataBase jobDataBase;
        [SerializeField] Transform parentTransform;

        Dictionary<ObjectiveData, ObjectiveViewer> objectiveViewerDict = new();

        public void Generate(ObjectiveData objectiveData)
        {
            var newObjective = Instantiate(objectiveViewerPrefab, parentTransform);
            var source1 = itemDataBase.GetData(objectiveData.CraftItem).Source1;
            var source2 = itemDataBase.GetData(objectiveData.CraftItem).Source2;
            var craftItem = itemDataBase.GetData(objectiveData.CraftItem).ItemName;
            var qty1 =  itemDataBase.GetData(objectiveData.CraftItem).Qty1;
            var qty2 = itemDataBase.GetData(objectiveData.CraftItem).Qty2;
            newObjective.Item1Image.SetImage(itemDataBase.GetData(source1).SourceImage);
            newObjective.Item2Image.SetImage(itemDataBase.GetData(source2).SourceImage);
            newObjective.CraftItemImage.SetImage(itemDataBase.GetData(craftItem).SourceImage);
            Debug.Log($"newObjective : {newObjective != null}");
            Debug.Log($"jobDataBase : {jobDataBase != null}");
            Debug.Log($"objectiveData : {objectiveData != null}");
            Debug.Log($"objectiveData.UpGradable : {objectiveData.UpGradable != null}");
            Debug.Log($"objectiveData.UpGradable.JobName : {objectiveData.UpGradable.JobName}");
            Debug.Log($"jobDataBase.GetData(objectiveData.UpGradable.JobName).SourceImage : {jobDataBase.GetData(objectiveData.UpGradable.JobName).SourceImage != null}");
            newObjective.EffectImage.SetImage(jobDataBase.GetData(objectiveData.UpGradable.JobName).SourceImage);
            newObjective.Item1Qty.SetText(qty1.ToString());
            newObjective.Item2Qty.SetText(qty2.ToString());

            objectiveViewerDict.Add(objectiveData, newObjective);
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
