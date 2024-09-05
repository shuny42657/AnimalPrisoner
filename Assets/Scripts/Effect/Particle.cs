using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public void Play(bool isActive)
    {
        if (isActive) particle.Play();
        else particle.Stop();
    }
}
