using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Factory;

namespace GameLogic.Map
{
    public class GrabbableVisualizer : MonoBehaviour,IGrabbableVisualizer
    {
        GameObject itemOnDisplay;
        [SerializeField] Transform parentTransform;

        public IMotherFactory<ItemName, GameObject> motherItemFactory;

        private void Awake()
        {
            motherItemFactory = GameObject.Find("MotherItemFactory").GetComponent<MotherItemFactory>();
        }

        public void Delete()
        {
            Destroy(itemOnDisplay);
            itemOnDisplay = null;
        }

        public void Show(ItemName itemName)
        {
            Debug.Log("Show");
            var newItem = motherItemFactory.Generate(itemName,parentTransform);
            if(newItem != null)
            {
                newItem.transform.localPosition = Vector3.zero;
                itemOnDisplay = newItem;
            }
        }
    }
}
