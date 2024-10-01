using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Data;


namespace GameLogic.GameSystem
{
    public interface IRoomParameterModifier
    {
        public void ModifyRoomParameter(ItemName item);
    }

    //Recover Room Parameters based on Items.
    public class RoomParameterModifier : MonoBehaviour, IRoomParameterModifier,ISwitchable
    {
        [SerializeField] ItemDataBase itemDataBase;
        [SerializeField] RoomParameter roomParameter;

        [SerializeField] bool isActive;
        public bool IsActive { get { return isActive; } set { isActive = value; } }

        public void ModifyRoomParameter(ItemName item)
        {
            var modifyParams = itemDataBase.GetData(item).RoomParamsToModify;
            var modifyValues = itemDataBase.GetData(item).RoomParamModifyValues;

            for(int i = 0; i < modifyParams.Count; i++)
            {
                var modifyParam = modifyParams[i];
                var modifyValue = modifyValues[i];
                switch (modifyParam)
                {
                    case RoomParameterName.Fuel:
                        roomParameter.Fuel += modifyValue;
                        break;
                    case RoomParameterName.Durability:
                        roomParameter.Durability += modifyValue;
                        break;
                    case RoomParameterName.Electricity:
                        roomParameter.Electricity += modifyValue;
                        break;
                }
            }
            
        }
    }
}
