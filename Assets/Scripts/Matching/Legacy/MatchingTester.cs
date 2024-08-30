using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

namespace Matching
{
    public class MatchingTester : MonoBehaviour
    {
        [SerializeField] Button startButton;
        [SerializeField] MatchingStarter matchingStarter;
        private void Awake()
        {
        }
        void Start()
        {
            startButton.onClick.AddListener(matchingStarter.OnButtonClick);
        }
    }
}
