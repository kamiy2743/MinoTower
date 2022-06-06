using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;
using Photon.Pun;
using Photon.Realtime;
using System.Threading;

namespace MT.SelectMatchScreen
{
    public class FriendMatch
    {
        private CancellationTokenSource _cts;
        private bool isInRoom;

        public FriendMatch()
        {
            _cts = new CancellationTokenSource();
        }

        public void Disconnect()
        {
            _cts.Cancel();

            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();
            }
        }

        public async UniTask RequestAsync(string roomName)
        {
            var isFirstUser = await JoinOrCreateRoomAsync(roomName);
            if (!isFirstUser)
            {
                Debug.Log("二人目");
                return;
            }

            Debug.Log("一人目");
            await Pun2TaskCallback.OnPlayerEnteredRoomAsync();
        }

        private async UniTask<bool> JoinOrCreateRoomAsync(string roomName)
        {
            try
            {
                var token = _cts.Token;

                if (!PhotonNetwork.IsConnected)
                {
                    // サーバに接続する
                    await Pun2TaskNetwork.ConnectUsingSettingsAsync(token);
                }

                var roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 2;

                // ルームへの参加または新規作成
                var isFirstUser = await Pun2TaskNetwork.JoinOrCreateRoomAsync(
                    roomName: roomName,
                    roomOptions: roomOptions,
                    typedLobby: default,
                    token: token);

                return isFirstUser;
            }
            catch (Pun2TaskNetwork.ConnectionFailedException ex)
            {
                // サーバに接続できなかった
                Debug.LogError(ex);
            }
            catch (Pun2TaskNetwork.FailedToCreateRoomException ex)
            {
                // 何らかの理由で部屋が作れなかった
                Debug.LogError(ex);
            }
            catch (Pun2TaskNetwork.FailedToJoinRoomException ex)
            {
                // 部屋に参加できなかった
                Debug.LogError(ex);
            }

            return false;
        }
    }
}
