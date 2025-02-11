using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLogic.Factory;
using Util;
using Photon.Realtime;
using Sync;
using GameLogic.GamePlayer;
using Photon.Pun;
using GameLogic.WorkSpace;
using UI;

namespace GameLogic.GameSystem
{
    /// <summary>
    /// 転送システムの初期化を行う
    /// </summary>
    public class TeleporterReceiverInitializer : IGameInitializer
    {
        IPlayer _player;
        List<TeleportWorkSpace> _teleporters;
        List<TeleportWorkSpace> _receivers;
        List<PlayerCustomPropertyCallback> _customPropCallbacks;
        KeyDownController _e_keyDownController;

        List<PlayerPropertyKey> sendItemKeys = new() { PlayerPropertyKey.from_player_1, PlayerPropertyKey.from_player_2, PlayerPropertyKey.from_player_3, PlayerPropertyKey.from_player_4 };

        public TeleporterReceiverInitializer(
            IPlayer player,
            List<TeleportWorkSpace> teleporters,
            List<TeleportWorkSpace> receivers,
            List<PlayerCustomPropertyCallback> customPropCallbacks,
            KeyDownController e_keyDownController
            )
        {
            _player = player;
            _teleporters = teleporters;
            _receivers = receivers;
            _customPropCallbacks = customPropCallbacks;
            _e_keyDownController = e_keyDownController;
        }
        public void InitializeGame()
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
                        var teleporterPutAndTake = new TeleporterWorkSpaceManagerFactory(_player, _e_keyDownController, _teleporters[increment].TeleportTextView, players[i - 1]).GenerateWorkSpaceManager(_teleporters[increment]);
                        var receiverPutAndTake = new ReceiverWorkSpaceManagerFactory(_player, _e_keyDownController, _receivers[increment].TeleportTextView, _customPropCallbacks[increment], players[i - 1].ActorNumber).GenerateWorkSpaceManager(_receivers[increment]);

                        _teleporters[increment].SetWorkSpaceManager(teleporterPutAndTake);
                        _receivers[increment].SetWorkSpaceManager(receiverPutAndTake);
                        _customPropCallbacks[increment].key = sendItemKeys[i - 1];
                        increment++;
                    }
                }
            }
        }

    }
    /// <summary>
    /// シグナルシステムの初期化を行う Added by Shinnosuke (2024/12/13)
    /// </summary>
    public class SignalInitializer : IGameInitializer
    {
        IPlayer _player;
        List<SignalViewerFactory> _receivers;
        List<PlayerCustomPropertyCallback> _customPropCallbacks;
        List<SignalViewer> _viewerPrefabs;
        List<PlayerPropertyKey> sendSignalKeys = new() { PlayerPropertyKey.sig_from_player_1, PlayerPropertyKey.sig_from_player_2, PlayerPropertyKey.sig_from_player_3, PlayerPropertyKey.sig_from_player_4 };

        public SignalInitializer(
            IPlayer player,
            List<SignalViewerFactory> receivers,
            List<SignalViewer> viewerPrefabs,
            List<PlayerCustomPropertyCallback> customPropCallbacks
            )
        {
            _player = player;
            _receivers = receivers;
            _viewerPrefabs = viewerPrefabs;
            _customPropCallbacks = customPropCallbacks;
        }
        public void InitializeGame()
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
                        _receivers[increment].SetSignalViwer(_viewerPrefabs[i-1]);
                        var signalReceiver = new SignalReceiverFactory(_customPropCallbacks[increment], players[i - 1].ActorNumber).GenerateSignalReceiver(_receivers[increment]);

                        _customPropCallbacks[increment].key = sendSignalKeys[i - 1];
                        increment++;
                    }
                }
            }
        }
    }
    /// <summary>
    /// プレイヤー情報表示システムの初期化を行う Added by Shinnosuke (2024/12/17)
    /// </summary>
    public class PlayerInfoInitializer : IGameInitializer
    {
        List<PlayerInfoViewer> _viewers;
        List<SignalViewerFactory> _receiverFactories;

        public PlayerInfoInitializer(
            List<PlayerInfoViewer> viewers
            )
        {
            _viewers = viewers;
        }
        public void InitializeGame()
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
                        _viewers[increment].ActorNumber = players[i - 1].ActorNumber;
                        _viewers[increment].PlayerName.SetText(players[i - 1].NickName);
                        //_viewers[increment].PlayerIcon.SetImage( );
                        //_viewers[increment].PlayerNameplate.SetImage( );

                        increment++;
                    }
                }
            }
        }
    }
}
