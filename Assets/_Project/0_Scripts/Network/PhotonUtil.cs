using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;
using Photon.Pun;
using Photon.Realtime;

namespace MT
{
    public static class PhotonUtil
    {
        public static async UniTask SetOfflineModeAsync()
        {
            if (PhotonNetwork.IsConnected)
            {
                await Pun2TaskNetwork.DisconnectAsync();
            }

            PhotonNetwork.OfflineMode = true;

            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 1;

            PhotonNetwork.CreateRoom(
                roomName: "",
                roomOptions: roomOptions,
                typedLobby: default);
        }

        public static void OnlineMode()
        {
            PhotonNetwork.OfflineMode = false;
        }

        public static async UniTask LeaveRoomAsync()
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.Log("not in room");
                return;
            }

            if (!PhotonNetwork.OfflineMode)
            {
                PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
                await Pun2TaskNetwork.LeaveRoomAsync();
                await Pun2TaskCallback.OnConnectedToMasterAsync();
            }
            else
            {
                PhotonNetwork.LeaveRoom();
            }

            Debug.Log("leave");
        }
    }
}
