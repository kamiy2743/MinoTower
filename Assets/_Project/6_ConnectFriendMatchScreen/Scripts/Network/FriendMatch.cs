using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;
using Photon.Pun;
using Photon.Realtime;
using System.Threading;

namespace MT.ConnectFriendMatchScreen
{
    public class FriendMatch
    {
        private CancellationTokenSource _cts;

        public FriendMatch()
        {
            _cts = new CancellationTokenSource();
        }

        public async UniTask Disconnect()
        {
            _cts.Cancel();

            if (PhotonNetwork.InRoom)
            {
                Debug.Log("leave");
                PhotonNetwork.LeaveRoom();
                await Pun2TaskCallback.OnLeftRoomAsync();
            }
        }

        /// <returns>success</returns>
        public async UniTask<bool> ConnectAsync(string roomName)
        {
            var (success, isFirstUser) = await JoinOrCreateRoomAsync(roomName);
            Debug.Log(success ? "接続成功" : "接続失敗");

            if (!success)
            {
                Debug.Log("failed");
                return false;
            }

            if (!isFirstUser)
            {
                Debug.Log("二人目");
                return true;
            }

            Debug.Log("一人目");
            await Pun2TaskCallback.OnPlayerEnteredRoomAsync();
            return true;
        }

        /// <returns>(success isFirtUser)</returns>
        private async UniTask<(bool, bool)> JoinOrCreateRoomAsync(string roomName)
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
                roomOptions.IsVisible = false;

                // ルームへの参加または新規作成
                var isFirstUser = await Pun2TaskNetwork.JoinOrCreateRoomAsync(
                    roomName: roomName,
                    roomOptions: roomOptions,
                    typedLobby: default,
                    token: token);

                return (true, isFirstUser);
            }
            catch (Pun2TaskNetwork.ConnectionFailedException ex)
            {
                // サーバに接続できなかった
                Debug.Log("サーバに接続できなかった");
                Debug.LogError(ex);
            }
            catch (Pun2TaskNetwork.FailedToCreateRoomException ex)
            {
                // 何らかの理由で部屋が作れなかった
                Debug.Log("何らかの理由で部屋が作れなかった");
                Debug.LogError(ex);
            }
            catch (Pun2TaskNetwork.FailedToJoinRoomException ex)
            {
                // 部屋に参加できなかった
                Debug.Log("部屋に参加できなかった");
                Debug.LogError(ex);
            }
            catch (System.OperationCanceledException ex)
            {
                Debug.Log("cancelled");
                Debug.LogError(ex);
            }

            return (false, false);
        }
    }
}
