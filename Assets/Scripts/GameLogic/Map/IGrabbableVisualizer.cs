using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbableVisualizer
{
    public void Show(ItemName itemName);
    public void Delete();
}
