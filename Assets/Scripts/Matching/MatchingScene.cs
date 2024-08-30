using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Photon.Pun;
using Photon.Realtime;

namespace Matching
{
    public class MatchingScene : MonoBehaviour, IScene
    {
        [SerializeField] string sceneName = "GameStarter";
        public void LoadScene()
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            Debug.Log("Moving on to match");
            PhotonNetwork.LoadLevel(sceneName);
        }
    }
}
