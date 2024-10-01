using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Data
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] ItemName itemName; public ItemName ItemName { get { return itemName; } }
        [SerializeField] ItemName source1; public ItemName Source1 { get { return source1; } }
        [SerializeField] int qty1; public int Qty1 { get { return qty1; } }
        [SerializeField] ItemName source2; public ItemName Source2 { get { return source2; } }
        [SerializeField] int qty2; public int Qty2 { get { return qty2; } }
        [SerializeField] Sprite sourceImage; public Sprite SourceImage { get { return sourceImage; } }
        [SerializeField] List<RoomParameterName> roomParamsToModify;
        public List<RoomParameterName> RoomParamsToModify { get { return roomParamsToModify; } }
        public RoomParameterName GetRoomParamToModify(int index) { return roomParamsToModify[index]; }
        [SerializeField] List<float> roomParamModifyValues;
        public List<float> RoomParamModifyValues { get { return roomParamModifyValues; } }
        public float GetRoomParamModifyValue(int index) { return roomParamModifyValues[index]; }
    }
}
