using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;

namespace Sync
{
    public class MatchingManager : MonoBehaviourPunCallbacks,IMatchinCallback
    {
        UnityEvent onRoomJoined = new();
        UnityEvent onMatchingComplete = new(); public UnityEvent OnMatchingComplete { get { return onMatchingComplete; } }
        public UnityEvent OnRoomJoined
        {
            get { return onRoomJoined; }
        }

        public override void OnJoinedRoom()
        {
            onRoomJoined.Invoke();
            if(PhotonNetwork.CurrentRoom.MaxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                PhotonNetwork.CurrentRoom.SetMatchComplete(true);
            }
        }

        public override void OnConnectedToMaster()
        {
            // ランダムなルームに参加する
            PhotonNetwork.JoinRandomRoom();
        }

        // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            // ルームの参加人数を2人に設定する
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 1;

            PhotonNetwork.CreateRoom(null, roomOptions);
        }
    }
}
