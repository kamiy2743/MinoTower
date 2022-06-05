using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class PlayerTurnProvider : MonoBehaviour
    {
        [SerializeField] private CustomPropertyConfig _config;

        private void Set(bool value)
        {
            CustomPropertyAccessor.Instance.Set<bool>(_config.IsMasterClientTurnKey, value);
        }

        private bool Get()
        {
            return CustomPropertyAccessor.Instance.Get<bool>(_config.IsMasterClientTurnKey);
        }

        public void Initialize()
        {
            var randValue = Random.value;
            Set(randValue > 0.5f);
        }

        public void NextTurn()
        {
            var currentTurn = Get();
            Set(!currentTurn);
        }

        public bool IsMyTurn()
        {
            var isMasterClient = PhotonNetwork.IsMasterClient;
            var isMasterClientTurn = Get();
            return isMasterClient ^ isMasterClientTurn;
        }
    }
}
