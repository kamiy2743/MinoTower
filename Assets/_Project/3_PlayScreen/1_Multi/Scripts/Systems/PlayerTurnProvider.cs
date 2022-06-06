using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Pun2Task;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Multi
{
    public class PlayerTurnProvider : MonoBehaviour
    {
        [SerializeField] private CustomPropertyConfig _config;

        private async UniTask SetIsMasterClientTurnAsync(bool value)
        {
            await RoomPropertyAccessor.Instance.SetAsync<bool>(_config.IsMasterClientTurnKey, value);
        }

        private bool GetIsMasterClientTurn()
        {
            return RoomPropertyAccessor.Instance.Get<bool>(_config.IsMasterClientTurnKey);
        }

        public async UniTask InitializeAsync()
        {
            if (!PhotonNetwork.IsMasterClient) return;

            var randValue = new CustomRandom().Value();
            await SetIsMasterClientTurnAsync(randValue > 0.5f);
        }

        public async UniTask NextTurnAsync()
        {
            if (!PhotonNetwork.IsMasterClient) return;

            var currentTurn = GetIsMasterClientTurn();
            await SetIsMasterClientTurnAsync(!currentTurn);
        }

        public bool IsMyTurn()
        {
            var isMasterClient = PhotonNetwork.IsMasterClient;
            var isMasterClientTurn = GetIsMasterClientTurn();
            return isMasterClient == isMasterClientTurn;
        }
    }
}
