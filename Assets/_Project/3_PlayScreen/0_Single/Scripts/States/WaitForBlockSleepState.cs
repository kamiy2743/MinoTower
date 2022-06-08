using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Single
{
    public class WaitForBlockSleepState : MonoBehaviour, IState, IStaticAwake, IStaticStart
    {
        [SerializeField] private BlockSleepProvider _blockSleepProvider;

        [Space(20)]
        [SerializeField] private GameObject _defaultNextStateObject;

        [Space(20)]
        [SerializeField] private GameOverArea _gameOverArea;
        [SerializeField] private ResultState _resultState;

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
                _cts.Cancel();
                ToNext(_resultState);
            });
        }

        public async void Enter()
        {
            _gameOverArea.SetIsListened(true);
            await WaitForBlockSleepAsync();

            ToNext(_defaultNextState);
        }

        private void ToNext(IState nextState)
        {
            _gameOverArea.SetIsListened(false);
            nextState.Enter();
        }

        private async UniTask WaitForBlockSleepAsync()
        {
            // ブロックがすべて停止してから遷移
            try
            {
                _cts = new CancellationTokenSource();
                await UniTask.WaitUntil(() => _blockSleepProvider.IsSleeping(), cancellationToken: _cts.Token);
            }
            catch (System.OperationCanceledException e)
            {
                Debug.Log("cancelled");
            }
        }
    }
}

