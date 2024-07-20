using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour, IGrabbable, IResource
{
    public ItemName ItemName { get { return ItemName.Oil; } }
}
