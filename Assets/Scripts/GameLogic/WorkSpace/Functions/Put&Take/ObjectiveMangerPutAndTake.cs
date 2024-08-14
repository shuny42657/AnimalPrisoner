using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.WorkSpace;
using GameLogic.GameSystem;
using UnityEngine.Events;

public class ObjectiveMangerPutAndTake : MonoBehaviour,IPutAndTake
{
    public ItemName Item => throw new System.NotImplementedException();

    UnityEvent<ItemName> onPut = new(); public UnityEvent<ItemName> OnPut { get { return onPut; } }

    UnityEvent onTake = new(); public UnityEvent OnTake { get { return onTake; } }
    [SerializeField] ObjectiveManager objectiveManager;
    [SerializeField] SerializeInterface<RoomParameterModifier> roomParamModifier;

    public bool Put(ItemName itemName)
    {
        var objectiveAchieved = objectiveManager.ObjectiveAchieved(itemName);
        if (objectiveAchieved)
        {
            Debug.Log("Achieved");
        }
        else
        {
            Debug.Log("Simply Used As Fuel");
            roomParamModifier.Value.ModifyRoomParameter(itemName);
        }
        return true;
    }

    public ItemName Take()
    {
        return ItemName.None;
    }
}
