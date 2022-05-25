using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen
{
    public class BlockStopState : MonoBehaviour, IState
    {
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private GameObject _defaultNextStateObject;
        [SerializeField] private ResultState _resultState;
        [SerializeField] private GameOverArea _gameOverArea;

        private IState _defaultNextState;

        private CancellationTokenSource _cts;

        void Awake()
        {
            _defaultNextState = _defaultNextStateObject.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        void Update()
        {
            if (_gameOverArea.IsTrigger())
            {
                _cts.Cancel();
                ToNext(_resultState);
            }
        }

        public async void Enter()
        {
            gameObject.SetActive(true);

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

        private void ToNext(IState nextState)
        {
            gameObject.SetActive(false);
            nextState.Enter();
        }
    }
}

