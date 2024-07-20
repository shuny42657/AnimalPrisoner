using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Factory
{
    public class ItemFactoryTest : MonoBehaviour
    {
        [SerializeField] MotherItemFactory motherItemFactory;

        void Start()
        {
            Debug.Log(motherItemFactory.Generate(ItemName.Stone, new Vector3(0f, 1f, 0f)));
            Debug.Log(motherItemFactory.Generate(ItemName.Wood, new Vector3(0f, 2f, 0f)));
            Debug.Log(motherItemFactory.Generate(ItemName.Iron, new Vector3(0f, 3f, 0f)));
            Debug.Log(motherItemFactory.Generate(ItemName.Oil, new Vector3(0f, 4f, 0f)));
            Debug.Log(motherItemFactory.Generate(ItemName.Water, new Vector3(0f, 5f, 0f)));
            Debug.Log(motherItemFactory.Generate(ItemName.Rice, new Vector3(0f, 6f, 0f)));
        }
    }
}