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
        var item = motherItemFactory.Generate(ItemName.Stone, Vector3.zero);
        floor.Put(item.GetComponent<IResource>());
        floor_2.Put(item.GetComponent<IResource>());
    }
}
