using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class WaitForBlockSleepState : MonoBehaviourPunCallbacks, IState, IStaticAwake, IStaticStart
    {
        [SerializeField] private BlockSleepProvider _blockSleepProvider;
        [SerializeField] private PlayerTurnProvider _playerTurnProvider;

        [Space(20)]
        [SerializeField] private GameObject _defaultNextStateObject;

        [Space(20)]
        [SerializeField] private GameOverArea _gameOverArea;
        // [SerializeField] private ResultState _resultState;

        private IState _defaultNextState;
        private CancellationTokenSource _cts;

        public void StaticAwake()
        {
            _defaultNextState = _defaultNextStateObject.GetComponent<IState>();
        }

        public void StaticStart()
        {
            _gameOverArea.AddListener(() =>
            {
                if (!_playerTurnProvider.IsMyTurn()) return;

                _cts.Cancel();
                // photonView.RPC(nameof(GameOver), RpcTarget.All);
            });
        }

        public void Enter()
        {
            if (!_playerTurnProvider.IsMyTurn()) return;

            _gameOverArea.SetIsListened(true);
            photonView.RequestOwnership();
            WaitForBlockSleep();
        }

        [PunRPC]
        private void ToDefaultState()
        {
            ToNext(_defaultNextState);
        }

        [PunRPC]
        private void GameOver()
        {
            // ToNext(_resultState);
        }

        private void ToNext(IState nextState)
        {
            _gameOverArea.SetIsListened(false);
            nextState.Enter();
        }

        private async void WaitForBlockSleep()
        {
            // ブロックがすべて停止してから遷移
            try
            {
                _cts = new CancellationTokenSource();
                await UniTask.WaitUntil(() => _blockSleepProvider.IsSleeping(), cancellationToken: _cts.Token);

                photonView.RPC(nameof(ToDefaultState), RpcTarget.All);
            }
            catch (System.OperationCanceledException e)
            {
                Debug.Log("cancelled");
            }
        }
    }
}

