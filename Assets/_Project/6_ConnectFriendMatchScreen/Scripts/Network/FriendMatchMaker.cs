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
    public class FriendMatchMaker
    {
        private CancellationTokenSource _cts;

        public FriendMatchMaker()
        {
            _cts = new CancellationTokenSource();
        }

        public async UniTask Disconnect()
        {
            _cts.Cancel();

            if (PhotonNetwork.InRoom)
            {
                await Pun2TaskNetwork.LeaveRoomAsync();
                await Pun2TaskCallback.OnConnectedToMasterAsync();
            }

            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            Debug.Log("leave");
        }

        /// <returns>success</returns>
        public async UniTask<bool> TryConnectAsync(string roomName)
        {
            try
            {
                var token = _cts.Token;

                if (!PhotonNetwork.IsConnected)
                {
                    // サーバに接続する
                    await Pun2TaskNetwork.ConnectUsingSettingsAsync(token);
                }

                var success = await JoinOrCreateRoomAsync(roomName, token);

                if (!success)
                {
                    return false;
                }

                if (PhotonNetwork.IsMasterClient)
                {
                    Debug.Log("一人目");
                    await Pun2TaskCallback.OnPlayerEnteredRoomAsync();
                }
                else
                {
                    Debug.Log("二人目");
                }

                return true;
            }
            catch (Pun2TaskNetwork.ConnectionFailedException ex)
            {
                // サーバに接続できなかった
                Debug.Log("サーバに接続できなかった");
                Debug.LogError(ex);
            }
            catch (System.OperationCanceledException ex)
            {
                Debug.Log("cancelled");
            }

            return false;
        }

        /// <returns>success</returns>
        private async UniTask<bool> JoinOrCreateRoomAsync(string roomName, CancellationToken token)
        {
            try
            {
                var roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 2;
                roomOptions.IsVisible = false;

                // ルームへの参加または新規作成
                await Pun2TaskNetwork.JoinOrCreateRoomAsync(
                    roomName: roomName,
                    roomOptions: roomOptions,
                    typedLobby: default,
                    token: token);

                return true;
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
            }

            return false;
        }
    }
}
