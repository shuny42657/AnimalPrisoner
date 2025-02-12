using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    void Start()
    {
        soundManager.PlayBGM(0);
    }
}
