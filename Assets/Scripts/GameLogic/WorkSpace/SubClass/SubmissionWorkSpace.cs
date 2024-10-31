using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.GameSystem;

namespace GameLogic.WorkSpace
{
    public class SubmissionWorkSpace : BaseWorkSpace
    {
        [SerializeField] ObjectiveManager _objectiveManager;
        [SerializeField] RoomParameterModifier _roomParamModifier;
        public override void InitializeWorkSpace()
        {
            base.InitializeWorkSpace();
            _putAndTake = new ObjectiveMangerPutAndTake(_objectiveManager, _roomParamModifier);
            var objManagerPutAndTake = (ObjectiveMangerPutAndTake)_putAndTake;
            _putAndTake.OnPut.AddListener((item) => _putAndTake.Put(item));
        }
    }
}
