using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTester : MonoBehaviour
{
    [SerializeField] Particle particle;
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) particle.Play(true);
        if (Input.GetKey(KeyCode.S)) particle.Play(false);
    }
}
