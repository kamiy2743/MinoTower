using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;
using System.Threading;
using Cysharp.Threading.Tasks;
using MT.Screens.PlayScreen.Stages;
using MT.Screens.PlayScreen.Systems;

namespace MT.Screens.PlayScreen.States
{
    public class WaitForBlockSleepState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private BlockSleepProvider _blockSleepProvider;
        [SerializeField] private GameObject _defaultNextStateObject;
        [SerializeField] private ResultState _resultState;
        [SerializeField] private GameOverArea _gameOverArea;

        private IState _defaultNextState;

        private CancellationTokenSource _cts;
        private bool _isActive = false;

        public void StaticAwake()
        {
            _defaultNextState = _defaultNextStateObject.GetComponent<IState>();
        }

        void Update()
        {
            if (!_isActive) return;

            // 土台から落ちたら結果画面に遷移
            if (_gameOverArea.IsTrigger())
            {
                _cts.Cancel();
                ToNext(_resultState);
            }
        }

        public void Enter()
        {
            _isActive = true;
            WaitForBlockSleep();
        }

        private void ToNext(IState nextState)
        {
            _isActive = false;
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

