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
        [SerializeField] private GameObject _nextState;
        public IState NextState { get; private set; }
        public void Enter()
        {
            gameObject.SetActive(true);
            // unitaskにしたい
            var blocks = _blocksParent.GetComponentsInChildren<Block>();
            StartCoroutine(WaitForAllStop(blocks));
        }
        public void Exit()
        {
            gameObject.SetActive(false);
            NextState.Enter();
        }

        void Awake()
        {
            NextState = _nextState.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        IEnumerator WaitForAllStop(Block[] blocks)
        {
            yield return new WaitUntil(() => IsStop(blocks));
            Exit();
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

