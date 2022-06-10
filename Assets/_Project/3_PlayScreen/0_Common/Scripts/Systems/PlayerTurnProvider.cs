using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Pun2Task;
using Cysharp.Threading.Tasks;
using MT.Network;

namespace MT.PlayScreen
{
    public class PlayerTurnProvider
    {
        private async UniTask SetIsMasterClientTurnAsync(bool value)
        {
            await PropertyAccessor.Instance.SetAsync<bool>(PropertyType.Room, PropertyKey.IsMasterClientTurn, value);
        }

        private bool GetIsMasterClientTurn()
        {
            return PropertyAccessor.Instance.Get<bool>(PropertyType.Room, PropertyKey.IsMasterClientTurn);
        }

        public async UniTask InitializeAsync()
        {
            if (PhotonNetwork.OfflineMode) return;
            if (!PhotonNetwork.IsMasterClient) return;

            var randValue = new CustomRandom().Value();
            await SetIsMasterClientTurnAsync(randValue > 0.5f);
        }

        public async UniTask NextTurnAsync()
        {
            if (PhotonNetwork.OfflineMode) return;
            if (!PhotonNetwork.IsMasterClient) return;

            var currentTurn = GetIsMasterClientTurn();
            await SetIsMasterClientTurnAsync(!currentTurn);
        }

        public bool IsMyTurn()
        {
            if (PhotonNetwork.OfflineMode)
            {
                return true;
            }

            var isMasterClient = PhotonNetwork.IsMasterClient;
            var isMasterClientTurn = GetIsMasterClientTurn();
            return isMasterClient == isMasterClientTurn;
        }
    }
}
