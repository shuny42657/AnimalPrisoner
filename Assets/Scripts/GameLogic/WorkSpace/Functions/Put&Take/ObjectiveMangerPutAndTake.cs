using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using GameLogic.GameSystem;
using UnityEngine.Events;

/// <summary>
/// Revised by Shinnosuke (2025/1/27)
/// </summary>
public class ObjectiveMangerPutAndTake : IPutAndTake
{
    UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

    UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }
    List<IObjectiveManager> _objectiveManagers;
    RoomParameterModifier _roomParamModifier;

    public ObjectiveMangerPutAndTake(List<IObjectiveManager> objectiveManagers,RoomParameterModifier roomParamModifier)
    {
        _objectiveManagers = objectiveManagers;
        _roomParamModifier = roomParamModifier;
    }
    
    public bool Put(ItemName itemName)
    {
        foreach (var objManager in _objectiveManagers)
        {
            var objectiveAchieved = objManager.ObjectiveAchieved(itemName);
            if (objectiveAchieved)
            {
                Debug.Log("Achieved");
            }
            else
            {
                Debug.Log("Simply Used As Fuel");
                _roomParamModifier.ModifyRoomParameter(itemName);
            }
        }
        return true;
    }

    public ItemName Take()
    {
        return ItemName.None;
    }
}
