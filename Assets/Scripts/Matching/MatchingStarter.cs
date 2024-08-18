using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

namespace Matching
{
    public class MatchingStarter : MonoBehaviour
    {
        [SerializeField] List<SerializeInterface<IMatchingView>> matchingViews;
        [SerializeField] GameObject startView;
        [SerializeField] GameObject matchingView;
        [SerializeField] CanvasGroup canvasGroup;
        public void OnStartButtonClick()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
            startView.SetActive(false);
            matchingView.SetActive(true);
            canvasGroup.interactable = true;
            foreach (var matchingView in matchingViews)
            {
                matchingView.Value.Setup();
            }
        }
    }
}
