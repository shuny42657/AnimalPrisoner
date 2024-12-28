using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UI;
using GameLogic.Factory;
using GameLogic.GamePlayer;

public class SignalViewerFactoryTest : MonoBehaviour
{
    //Player
    PlayerManager _playerManager;
    [SerializeField] MainPlayerFactory playerFactory;
    private void Start()
    {
        _playerManager = playerFactory.GeneratePlayer(Vector3.zero);
    }
    public void InitializeViewer()
    {
        var players = PhotonNetwork.PlayerList;
        if (players.Length == 1)
        {
            return;
        }
        else
        {
            int increment = 0;
            for (int i = 1; i < players.Length + 1; i++)
            {
                if (i == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    continue;
                }
                else
                {
                    //var signalViewer = new SignalViewerFactory(_playerManager, _teleporters[increment].TeleportTextView, players[i - 1]).GenerateWorkSpaceManager(_teleporters[increment]);
                    //var receiverPutAndTake = new ReceiverWorkSpaceManagerFactory(_player, _e_keyDownController, _receivers[increment].TeleportTextView, _customPropCallbacks[increment], players[i - 1].ActorNumber).GenerateWorkSpaceManager(_receivers[increment]);

                    //_teleporters[increment].SetWorkSpaceManager(teleporterPutAndTake);
                    //_receivers[increment].SetWorkSpaceManager(receiverPutAndTake);
                    //_customPropCallbacks[increment].key = sendItemKeys[i - 1];
                    increment++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InitializeViewer();
        }
    }
}
