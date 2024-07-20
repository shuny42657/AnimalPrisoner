using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice : MonoBehaviour, IGrabbable, IResource
{
    public ItemName ItemName { get { return ItemName.Rice; } }
}
