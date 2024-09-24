using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke (2024/9/25)
    /// </summary>
    private SoundManager soundManager;
    public void Start()
    {
        soundManager = SoundManager.Instance;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            soundManager.Play(SoundManager.BGMSoundData.BGM.Game);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            soundManager.Play(SoundManager.BGMSoundData.BGM.Title);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            soundManager.Play(SoundManager.SESoundData.SE.Decide);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            soundManager.Play(SoundManager.SESoundData.SE.Cancel);
        }
    }
}
