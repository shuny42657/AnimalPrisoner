using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkSpaceFactory 
{
    public IOperatable GenerateWorkSpace(Vector3 position); 
}
