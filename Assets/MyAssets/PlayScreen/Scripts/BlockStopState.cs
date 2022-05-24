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
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            // unitaskにしたい
            var blocks = _blocksParent.GetComponentsInChildren<Block>();
            StartCoroutine(WaitForAllStop(blocks));
        }

        private void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }

        IEnumerator WaitForAllStop(Block[] blocks)
        {
            yield return new WaitUntil(() => IsStop(blocks));
            ToNext();
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

