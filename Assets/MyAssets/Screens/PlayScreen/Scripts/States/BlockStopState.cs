using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;
using System.Threading;
using Cysharp.Threading.Tasks;
using MT.Screens.PlayScreen.Stages;

namespace MT.Screens.PlayScreen.States
{
    public class BlockStopState : MonoBehaviour, IState
    {
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private GameObject _defaultNextStateObject;
        [SerializeField] private ResultState _resultState;
        [SerializeField] private GameOverArea _gameOverArea;

        private IState _defaultNextState;

        private CancellationTokenSource _cts;
        private bool _isActive = false;

        void Awake()
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
            WaitForAllStop();
        }

        private void ToNext(IState nextState)
        {
            _isActive = false;
            nextState.Enter();
        }

        private async void WaitForAllStop()
        {
            // ブロックがすべて停止してから遷移
            try
            {
                _cts = new CancellationTokenSource();
                await UniTask.WaitUntil(() => _blockStore.IsStop(), cancellationToken: _cts.Token);
                ToNext(_defaultNextState);
            }
            catch (System.OperationCanceledException e)
            {
                Debug.Log("cancelled");
            }
        }
    }
}

