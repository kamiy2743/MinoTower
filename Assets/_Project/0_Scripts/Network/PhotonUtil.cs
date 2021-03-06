using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;
using Photon.Pun;
using Photon.Realtime;
using System.Threading;

namespace MT
{
    public static class PhotonUtil
    {
        public static async UniTask SetOfflineModeAsync()
        {
            if (PhotonNetwork.OfflineMode) return;

            if (PhotonNetwork.IsConnected)
            {
                await Pun2TaskNetwork.DisconnectAsync();
            }

            PhotonNetwork.OfflineMode = true;
            PhotonNetwork.JoinRoom("");
        }

        /// <returns>Success</returns>
        public static async UniTask<bool> ConnectAsync(CancellationToken token)
        {
            if (PhotonNetwork.OfflineMode)
            {
                PhotonNetwork.OfflineMode = false;
            }

            try
            {
                await Pun2TaskNetwork.ConnectUsingSettingsAsync(token);
                NetworkErrorObserver.Instance.SetIsListened(true);
                return true;
            }
            catch (Pun2TaskNetwork.ConnectionFailedException ex)
            {
                // サーバに接続できなかった
                Debug.Log("サーバに接続できなかった");
                Debug.LogError(ex);
            }
            catch (System.OperationCanceledException e)
            {
                Debug.Log("connect cancelled");
            }

            return false;
        }

        public static async UniTask DisconnectAsync()
        {
            NetworkErrorObserver.Instance.SetIsListened(false);

            await LeaveRoomAsync();

            if (PhotonNetwork.OfflineMode)
            {
                PhotonNetwork.Disconnect();
            }
            else
            {
                await Pun2TaskNetwork.DisconnectAsync();
            }
        }

        private static async UniTask LeaveRoomAsync()
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.Log("not in room");
                return;
            }

            if (PhotonNetwork.OfflineMode)
            {
                PhotonNetwork.LeaveRoom();
            }
            else
            {
                PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
                await Pun2TaskNetwork.LeaveRoomAsync();
                await Pun2TaskCallback.OnConnectedToMasterAsync();
            }

            Debug.Log("leave");
        }

        /// <returns>Success</returns>
        public static async UniTask<bool> WaitForOtherPlayerAsync(CancellationToken token)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.Log("二人目");
                return true;
            }

            Debug.Log("一人目");
            try
            {
                await Pun2TaskCallback.OnPlayerEnteredRoomAsync().AttachExternalCancellation(token);
                return true;
            }
            catch (System.OperationCanceledException ex)
            {
                Debug.Log("wait for other player cancelled");
            }

            return false;
        }
    }
}
