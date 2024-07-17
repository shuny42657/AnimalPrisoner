using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour, IGrabbable, IResource
{
    public ItemName ItemName { get { return ItemName.Wood; } }
}
