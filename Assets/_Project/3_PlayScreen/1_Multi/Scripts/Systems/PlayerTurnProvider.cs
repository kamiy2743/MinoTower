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

        private void SetIsMasterClientTurn(bool value)
        {
            CustomPropertyAccessor.Instance.Set<bool>(_config.IsMasterClientTurnKey, value);
        }

        private bool GetIsMasterClientTurn()
        {
            return CustomPropertyAccessor.Instance.Get<bool>(_config.IsMasterClientTurnKey);
        }

        public async UniTask Initialize()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                var randValue = new CustomRandom().Value();
                // SetIsMasterClientTurn(randValue > 0.5f);
                // TODO test
                SetIsMasterClientTurn(!PhotonNetwork.IsMasterClient);
            }

            await Pun2TaskCallback.OnRoomPropertiesUpdateAsync();
        }

        public async UniTask NextTurn()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                var currentTurn = GetIsMasterClientTurn();
                SetIsMasterClientTurn(!currentTurn);
            }

            await Pun2TaskCallback.OnRoomPropertiesUpdateAsync();
        }

        public bool IsMyTurn(bool log = false)
        {
            var isMasterClient = PhotonNetwork.IsMasterClient;
            var isMasterClientTurn = GetIsMasterClientTurn();
            if (log)
                Debug.Log("provider: " + (isMasterClient == isMasterClientTurn));
            return isMasterClient == isMasterClientTurn;
        }
    }
}
