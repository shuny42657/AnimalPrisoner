using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Factory;
using GameLogic.WorkSpace;

public class PutItemOnFloor : MonoBehaviour
{
    [SerializeField]  BaseWorkSpace floor;
    [SerializeField] BaseWorkSpace floor_2;
    [SerializeField] MotherItemFactory motherItemFactory;
    // Start is called before the first frame update
    void Start()
    {
        floor.Put(ItemName.Stone);
        floor_2.Put(ItemName.Iron);
    }
}
