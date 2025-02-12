using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class BGMStarter : MonoBehaviour
    {
        [SerializeField] SoundManager soundManager;
        [SerializeField] 
        public void Start()
        {
            soundManager.PlayBGM(0);
        }
    }
}
