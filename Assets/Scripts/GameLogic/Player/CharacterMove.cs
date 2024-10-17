using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour, IMovable
{
    [SerializeField] Transform _transform;
    public bool CanMove { get; set; }
    [SerializeField] float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }


    public void MoveHorizontal(float speed)
    {
        if (CanMove)
        {
            _transform.Translate(Time.deltaTime * this.speed * speed, 0f, 0f);
        }
    }

    public void MoveVertical(float speed)
    {
        if (CanMove)
        {
            _transform.Translate(0f, 0f, Time.deltaTime * this.speed * speed);
        }
    }
}
