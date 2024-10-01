using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;
using GameLogic.WorkSpace;

namespace GameLogic.Map
{
    public interface IMapBuilder
    {
        public List<BaseWorkSpace> BuildWorkSpaces(IJobStatus jobStatus);
    }
}
