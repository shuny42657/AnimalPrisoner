using System.Collections;
using System.Collections.Generic;
using GameLogic.GamePlayer;
using UnityEngine;
using GameLogic.Factory;
using GameLogic.WorkSpace;
using UnityEngine.Events;


namespace GameLogic.Map
{
    public class MapBuilder : MonoBehaviour,IMapBuilder
    {
        IPlayer _player; public void SetPlayer(IPlayer player) { _player = player; }
        [SerializeField] MotherWorkSpaceFactory motherWorkSpaceFactory;
        [SerializeField] List<Vector3> positionCandidates;
        HashSet<int> occupiedPositions = new();
        [SerializeField]UnityEvent<IUpGradable> onWorkSpaceGenerated;

        List<WorkSpace.WorkSpace> floors;
        public List<BaseWorkSpace> BuildWorkSpaces(IJobStatus jobStatus)
        {
            List<BaseWorkSpace> workSpaces = new();
            Debug.Log($"Job Count{jobStatus.GetAllJobs().Count}");
            foreach(var j in jobStatus.GetAllJobs())
            {
                Debug.Log($"Job : {j}");
                for(int i = 0;i < 100; i++)
                {
                    var rand = Random.Range(0, positionCandidates.Count);
                    if (!occupiedPositions.Contains(rand))
                    {
                        var workSpace = motherWorkSpaceFactory.Generate(j, positionCandidates[rand]);
                        //onWorkSpaceGenerated.Invoke(workSpace.GetComponent<BaseWorkSpace>().UpGradable);
                        //workSpaces.Add(workSpace.GetComponent<BaseWorkSpace>());
                        occupiedPositions.Add(rand);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return workSpaces;
        }
    }
}
