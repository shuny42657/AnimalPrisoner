using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    public void PlayOneShot()
    {
        audioSource.PlayOneShot(audioClip);
    }
    public void Play()
    {
        audioSource.Play();
    }
    public void Stop()
    {
        audioSource.Stop();
    }
}
