using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public bool CanMove { get; set; }
    public float Speed { get; set; }
    public void MoveHorizontal(float speed);
    public void MoveVertical(float speed);
}
