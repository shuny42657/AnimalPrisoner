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
        [SerializeField] int playerCount;
        UnityEvent onRoomJoined = new();
        UnityEvent onMatchingComplete = new(); public UnityEvent OnMatchingComplete { get { return onMatchingComplete; } }
        public UnityEvent OnRoomJoined
        {
            get { return onRoomJoined; }
        }

        public override void OnJoinedRoom()
        {
            Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
            onRoomJoined.Invoke();
            if(PhotonNetwork.CurrentRoom.MaxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                PhotonNetwork.CurrentRoom.SetMatchComplete(true);
            }
        }

        public override void OnConnectedToMaster()
        {
            // ランダムなルームに参加する
            PhotonNetwork.JoinRoom("Room");
        }

        // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            // ルームの参加人数を2人に設定する
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = playerCount;

            PhotonNetwork.CreateRoom("Room", roomOptions);
        }
    }
}
