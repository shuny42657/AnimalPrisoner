using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace GameLogic.GameSystem
{
    public class SceneLoadManager
    {
        public static void MoveToTitle()
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Title");
        }
    }
}

