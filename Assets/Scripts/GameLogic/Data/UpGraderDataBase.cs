using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;


namespace GameLogic.Data
{
    public class UpGraderDataBase : MonoBehaviour,IDataBase<UpGraderData,UpGraderName>
    {
        [SerializeField] List<UpGraderData> upgraderData;
        Dictionary<UpGraderName, UpGraderData> upgraderDict = new();

        private void Awake()
        {
            foreach(var u in upgraderData)
            {
                upgraderDict.Add(u.UpGraderName, u);
            }
        }

        public IEnumerable<UpGraderData> GetAllData()
        {
            return upgraderData;
        }

        public UpGraderData GetData(UpGraderName name)
        {
            return upgraderDict[name];
        }
    }
}
