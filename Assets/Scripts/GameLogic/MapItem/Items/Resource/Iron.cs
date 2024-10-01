using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour, IGrabbable, IResource
{
    public ItemName ItemName { get { return ItemName.Iron; } }
}
