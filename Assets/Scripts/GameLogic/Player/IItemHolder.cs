using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemHolder 
{
    public void Grab(IGrabbable grabbable);
    public IGrabbable Release();
}
