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
        soundManager.PlayBGM((int)(SoundManager.BGMSoundData.BGM.Title));
    }
}
