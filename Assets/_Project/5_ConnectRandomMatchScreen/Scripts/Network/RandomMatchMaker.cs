using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;
using Photon.Pun;
using Photon.Realtime;
using System.Threading;

namespace MT.ConnectRandomMatchScreen
{
    public class RandomMatchMaker
    {
        private CancellationTokenSource _cts;

        public async UniTask CancelAsync()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }

            await PhotonUtil.LeaveRoomAsync();
        }

        /// <returns>Success</returns>
        public async UniTask<bool> JoinRoomAsync()
        {
            try
            {
                _cts = new CancellationTokenSource();
                var token = _cts.Token;

                if (!PhotonNetwork.IsConnected)
                {
                    // サーバに接続する
                    await Pun2TaskNetwork.ConnectUsingSettingsAsync(token);
                }

                PhotonUtil.OnlineMode();

                var success = await JoinRandomOrCreateRoom(token);

                if (!success)
                {
                    return false;
                }

                if (PhotonNetwork.IsMasterClient)
                {
                    Debug.Log("一人目");
                    try
                    {
                        await Pun2TaskCallback.OnPlayerEnteredRoomAsync().AttachExternalCancellation(token);
                    }
                    catch (System.OperationCanceledException ex)
                    {
                        Debug.Log("cancelled");
                        return false;
                    }
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

        /// <returns>Success</returns>
        private async UniTask<bool> JoinRandomOrCreateRoom(CancellationToken token)
        {
            try
            {
                await Pun2TaskNetwork.JoinRandomRoomAsync(
                    expectedCustomRoomProperties: default,
                    expectedMaxPlayers: 2,
                    matchingType: default,
                    typedLobby: default,
                    sqlLobbyFilter: default,
                    token: token);

                Debug.Log("random join");
                return true;
            }
            catch (Pun2TaskNetwork.FailedToJoinRoomException ex)
            {
                var success = await CreateRoom(token);
                return success;
            }
            catch (System.OperationCanceledException ex)
            {
                Debug.Log("cancelled");
            }

            return false;
        }

        /// <returns>Success</returns>
        private async UniTask<bool> CreateRoom(CancellationToken token)
        {
            try
            {
                var roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 2;

                await Pun2TaskNetwork.CreateRoomAsync(
                    roomName: "",
                    roomOptions: roomOptions,
                    typedLobby: default,
                    token: token);

                Debug.Log("create room");
                return true;
            }
            catch (Pun2TaskNetwork.FailedToCreateRoomException ex)
            {
                // 何らかの理由で部屋が作れなかった
                Debug.Log("何らかの理由で部屋が作れなかった");
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
