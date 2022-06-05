using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class ToNextTurnState : MonoBehaviourPunCallbacks, IState, IStaticAwake
    {
        [SerializeField] private PlayerTurnProvider _playerTurnProvider;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            await _playerTurnProvider.NextTurn();

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
