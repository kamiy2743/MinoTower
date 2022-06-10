using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class ToNextTurnState : MonoBehaviourPunCallbacks, IState, IStaticAwake
    {
        [SerializeField] private GameObject _nextStateObject;

        private PlayerTurnProvider _playerTurnProvider = new PlayerTurnProvider();
        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            await _playerTurnProvider.NextTurnAsync();

            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC(nameof(ToNext), RpcTarget.All);
            }
        }

        [PunRPC]
        private void ToNext()
        {
            _nextState.Enter();
        }
    }
}
