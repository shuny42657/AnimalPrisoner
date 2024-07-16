using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public void MoveHorizontal(float speed);
    public void MoveVertical(float speed);
}
