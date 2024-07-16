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
            motherItemFactory.Generate(ItemName.Stone);
        }
    }
}