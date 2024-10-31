using System.Collections;
using System.Collections.Generic;
using GameLogic.GamePlayer;
using UnityEngine;
using GameLogic.Factory;
using GameLogic.WorkSpace;
using UnityEngine.Events;
using Util;


namespace GameLogic.Map
{
    public class MapBuilder : MonoBehaviour,IMapBuilder
    {
        IPlayer _player; public void SetPlayer(IPlayer player) { _player = player; }
        [SerializeField] MakerCrafterFactory motherWorkSpaceFactory;
        [SerializeField] List<Vector3> positionCandidates;
        [SerializeField] KeyDownController _e_KeyDownController;
        HashSet<int> occupiedPositions = new();
        public UnityEvent<WorkSpaceManager> OnWorkSpaceGenerated;
        List<WorkSpaceManager> workSpaceMangers = new();
        [SerializeField] List<WorkSpace.WorkSpace> floors;
        FloorWorkSpaceManagerFactory _floorWorkSpaceFactory;

        public void BuildWorkSpaces(IJobStatus jobStatus)
        {
            _floorWorkSpaceFactory = new(_player, _e_KeyDownController);
            foreach(var f in floors)
            {
                f.SetWorkSpaceManager(_floorWorkSpaceFactory.GenerateWorkSpaceController(f));
            }

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
                        //Debug.Log($"WorkSpace : {workSpace != null}");
                        workSpaceMangers.Add(workSpace.GetWorkSpaceManager());
                        OnWorkSpaceGenerated.Invoke(workSpace.GetWorkSpaceManager());
                        occupiedPositions.Add(rand);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public List<WorkSpaceManager> GetWorkSpaces()
        {
            return workSpaceMangers;
        }
    }
}
