using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameLogic.WorkSpace
{
    public class CrafterAutomatable : SimpleAutomatable
    {
        //bool working;
        //ItemName itemToCraft;
        IConditionChecker _conditionChecker;

        public CrafterAutomatable(
            float maxProgress,
            IConditionChecker conditionChecker
            ) : base(maxProgress)
        {
            _conditionChecker = conditionChecker;
        }
        

        public override void InitiateOperation()
        {
            if (_conditionChecker.MeetCondition())
            {
                onOperationInitiated.Invoke();
                IsActive = true;
            }
            else
            {
                Debug.Log("Cannot Start Operation");
            }
        }
    }
}
