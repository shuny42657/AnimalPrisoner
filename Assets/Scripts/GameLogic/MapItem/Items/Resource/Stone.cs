using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, IGrabbable, IResource
{
    public ItemName ItemName { get { return ItemName.Stone; } }
}
