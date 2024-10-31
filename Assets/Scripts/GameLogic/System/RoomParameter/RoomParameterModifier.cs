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
    public class RoomParameterModifier : IRoomParameterModifier
    {
        [SerializeField] ItemDataBase _itemDataBase;
        [SerializeField] RoomParameter _roomParam;

        public RoomParameterModifier(ItemDataBase itemDataBase,RoomParameter roomParam)
        {
            _itemDataBase = itemDataBase;
            _roomParam = roomParam;
        }

        public void ModifyRoomParameter(ItemName item)
        {
            var modifyParams = _itemDataBase.GetData(item).RoomParamsToModify;
            var modifyValues = _itemDataBase.GetData(item).RoomParamModifyValues;

            for(int i = 0; i < modifyParams.Count; i++)
            {
                var modifyParam = modifyParams[i];
                var modifyValue = modifyValues[i];
                switch (modifyParam)
                {
                    case RoomParameterName.Fuel:
                        _roomParam.Fuel += modifyValue;
                        break;
                    case RoomParameterName.Durability:
                        _roomParam.Durability += modifyValue;
                        break;
                    case RoomParameterName.Electricity:
                        _roomParam.Electricity += modifyValue;
                        break;
                }
            }
        }
    }
}
