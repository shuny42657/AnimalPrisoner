using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GamePlayer;

namespace GameLogic.Map
{
    public interface IMapBuilder
    {
        public void BuildWorkSpaces(IJobStatus jobStatus);
    }
}
