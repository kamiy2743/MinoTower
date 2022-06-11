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

        public async UniTask CancelAsync()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }

            await PhotonUtil.DisconnectAsync();
        }

        /// <returns>success</returns>
        public async UniTask<bool> JoinRoomAsync(string roomName)
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            if (!await PhotonUtil.ConnectAsync(token)) return false;

            if (!await JoinOrCreateRoomAsync(roomName, token)) return false;

            if (!await PhotonUtil.WaitForOtherPlayerAsync(token)) return false;

            new CurrentMatchTypeAccessor().Set(MatchType.Friend);

            return true;
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
                Debug.Log("join or create room cancelled");
            }

            return false;
        }
    }
}
