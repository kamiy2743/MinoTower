using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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

        public void Initialize()
        {
            if (!PhotonNetwork.IsMasterClient) return;

            var randValue = new CustomRandom().Value();
            SetIsMasterClientTurn(randValue > 0.5f);
            // TODO test
            SetIsMasterClientTurn(!PhotonNetwork.IsMasterClient);
        }

        public void NextTurn()
        {
            if (!PhotonNetwork.IsMasterClient) return;

            var currentTurn = GetIsMasterClientTurn();
            SetIsMasterClientTurn(!currentTurn);
        }

        public bool IsMyTurn()
        {
            var isMasterClient = PhotonNetwork.IsMasterClient;
            var isMasterClientTurn = GetIsMasterClientTurn();
            return isMasterClient == isMasterClientTurn;
        }
    }
}
