using System.Collections;
using System.Collections.Generic;
using GameLogic.GamePlayer;
using UnityEngine;
using GameLogic.Factory;

namespace GameLogic.Map
{
    public class MapBuilder : MonoBehaviour,IMapBuilder
    {
        [SerializeField] MotherWorkSpaceFactory motherWorkSpaceFactory;
        [SerializeField] List<Vector3> positionCandidates;
        HashSet<int> occupiedPositions = new();
        public void BuildWorkSpaces(IJobStatus jobStatus)
        {
            Debug.Log($"Job Count{jobStatus.GetAllJobs().Count}");
            foreach(var j in jobStatus.GetAllJobs())
            {
                for(int i = 0;i < 100; i++)
                {
                    var rand = Random.Range(0, positionCandidates.Count);
                    if (!occupiedPositions.Contains(rand))
                    {
                        motherWorkSpaceFactory.Generate(j, positionCandidates[rand]);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
