using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Written by Shinnosuke
/// </summary>
public class ParticleEffectPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public void Play(bool isActive)
    {
        if (isActive) particle.Play();
        else particle.Stop();
    }
}
