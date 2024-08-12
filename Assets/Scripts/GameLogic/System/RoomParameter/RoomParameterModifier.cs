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
    public class RoomParameterModifier : MonoBehaviour, IRoomParameterModifier
    {
        [SerializeField] ItemDataBase itemDataBase;
        [SerializeField] RoomParameter roomParameter;

        public void ModifyRoomParameter(ItemName item)
        {
            var modifyParam = itemDataBase.GetData(item).RoomParamToModify;
            var modifyValue = itemDataBase.GetData(item).RoomParamModifyValue;
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
