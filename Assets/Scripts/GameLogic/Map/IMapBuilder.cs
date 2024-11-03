using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using GameLogic.WorkSpace;

namespace GameLogic.Map
{
    public interface IMapBuilder
    {
        public void BuildWorkSpaces(IJobStatus jobStatus);
        public List<WorkSpaceManager> GetWorkSpaces();
    }
}
