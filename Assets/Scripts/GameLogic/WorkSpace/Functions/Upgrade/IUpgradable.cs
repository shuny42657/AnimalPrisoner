using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.WorkSpace
{
    public interface IUpGradable
    {
        public void UpGrade();
        public int Level { get; }
    }
}
