using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;
using MT.Blocks;

namespace MT.PlayScreen
{
    public class BlockStopState : MonoBehaviour, IState
    {
        [SerializeField] private Transform _blocksParent;
        [SerializeField] private GameObject _defaultNextStateObject;
        [SerializeField] private ResultState _resultState;
        [SerializeField] private GameOverArea _gameOverArea;

        private IState _defaultNextState;

        void Awake()
        {
            _defaultNextState = _defaultNextStateObject.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        void Update()
        {
            if (_gameOverArea.IsTrigger())
            {
                // 遷移前にコルーチンを止めろ
                ToNext(_resultState);
            }
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            // unitaskにしたい
            var blocks = _blocksParent.GetComponentsInChildren<Block>();
            StartCoroutine(WaitForAllStop(blocks));
        }

        private void ToNext(IState nextState)
        {
            gameObject.SetActive(false);
            nextState.Enter();
        }

        IEnumerator WaitForAllStop(Block[] blocks)
        {
            yield return new WaitUntil(() => IsStop(blocks));
            ToNext(_defaultNextState);
        }

        private bool IsStop(Block[] blocks)
        {
            foreach (var block in blocks)
            {
                if (!block.IsStop())
                    return false;
            }

            return true;
        }
    }
}

