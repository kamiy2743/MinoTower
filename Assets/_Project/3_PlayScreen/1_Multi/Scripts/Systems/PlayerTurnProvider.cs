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

        private async UniTask SetIsMasterClientTurn(bool value)
        {
            await CustomPropertyAccessor.Instance.Set<bool>(_config.IsMasterClientTurnKey, value);
        }

        private bool GetIsMasterClientTurn()
        {
            return CustomPropertyAccessor.Instance.Get<bool>(_config.IsMasterClientTurnKey);
        }

        public async UniTask Initialize()
        {
            if (!PhotonNetwork.IsMasterClient) return;

            var randValue = new CustomRandom().Value();
            await SetIsMasterClientTurn(randValue > 0.5f);
        }

        public async UniTask NextTurn()
        {
            if (!PhotonNetwork.IsMasterClient) return;

            var currentTurn = GetIsMasterClientTurn();
            await SetIsMasterClientTurn(!currentTurn);
        }

        public bool IsMyTurn()
        {
            var isMasterClient = PhotonNetwork.IsMasterClient;
            var isMasterClientTurn = GetIsMasterClientTurn();
            return isMasterClient == isMasterClientTurn;
        }
    }
}
