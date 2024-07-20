using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IGrabbable, IResource
{
    public ItemName ItemName { get { return ItemName.Water; } }
}
