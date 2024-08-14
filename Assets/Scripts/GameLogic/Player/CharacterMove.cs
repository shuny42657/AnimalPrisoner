using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour, IMovable
{
    public bool CanMove { get; set; }
    public float Speed { get; set; }

    public void MoveHorizontal(float speed)
    {
        transform.Translate(Time.deltaTime * Speed, 0f, 0f);
    }

    public void MoveVertical(float speed)
    {
        transform.Translate(0f, 0f, Time.deltaTime * Speed);
    }
}
