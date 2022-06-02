using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen
{
    public class WaitForBlockSleepState : MonoBehaviour, IState, IStaticAwake, IStaticStart
    {
        [SerializeField] private BlockSleepProvider _blockSleepProvider;
        [SerializeField] private GameObject _defaultNextStateObject;
        [SerializeField] private ResultState _resultState;
        [SerializeField] private GameOverArea _gameOverArea;

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

        public void Enter()
        {
            _gameOverArea.SetIsListened(true);
            WaitForBlockSleep();
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
                ToNext(_defaultNextState);
            }
            catch (System.OperationCanceledException e)
            {
                Debug.Log("cancelled");
            }
        }
    }
}

