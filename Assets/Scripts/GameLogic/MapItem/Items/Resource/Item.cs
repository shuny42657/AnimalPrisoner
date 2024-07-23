using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IResource
{
    [SerializeField] ItemName itemName;
    public ItemName ItemName { get { return itemName; } }
}
