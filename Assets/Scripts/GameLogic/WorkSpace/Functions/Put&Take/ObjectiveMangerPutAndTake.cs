using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using GameLogic.GameSystem;
using UnityEngine.Events;

public class ObjectiveMangerPutAndTake : IPutAndTake
{
    UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

    UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }
    ObjectiveManager _objectiveManager;
    RoomParameterModifier _roomParamModifier;

    public ObjectiveMangerPutAndTake(ObjectiveManager objectiveManager,RoomParameterModifier roomParamModifier)
    {
        _objectiveManager = objectiveManager;
        _roomParamModifier = roomParamModifier;
    }
    
    public bool Put(ItemName itemName)
    {
        var objectiveAchieved = _objectiveManager.ObjectiveAchieved(itemName);
        if (objectiveAchieved)
        {
            Debug.Log("Achieved");
        }
        else
        {
            Debug.Log("Simply Used As Fuel");
            _roomParamModifier.ModifyRoomParameter(itemName);
        }
        return true;
    }

    public ItemName Take()
    {
        return ItemName.None;
    }
}
