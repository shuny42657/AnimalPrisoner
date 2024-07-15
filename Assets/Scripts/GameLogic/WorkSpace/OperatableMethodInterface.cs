using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemPutter
{
    public void Put(IGrabbable grabbable);
}

public interface IItemTaker
{
    public IGrabbable Take();
}

public interface IWorker
{
    public void Work();
}
