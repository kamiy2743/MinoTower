using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;
using MT.Blocks;
using DG.Tweening;

namespace MT.PlayScreen
{
    public class ScreenScrollState : MonoBehaviour, IState
    {
        [SerializeField] private float _scrollDuration;
        [SerializeField] private Transform _blocksParent;
        [SerializeField] private GameObject _nextState;
        public IState NextState { get; private set; }
        public void Enter()
        {
            gameObject.SetActive(true);
            ScreenScroll();
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

        private void ScreenScroll()
        {
            var maxY = Mathf.Max(0, CalcMaxY());
            var cameraTransfrom = Camera.main.transform;
            cameraTransfrom.DOMoveY(maxY, _scrollDuration).OnComplete(() =>
            {
                Exit();
            });
        }

        private float CalcMaxY()
        {
            var maxY = float.NegativeInfinity;

            var blocks = _blocksParent.GetComponentsInChildren<Block>();
            foreach (var block in blocks)
            {
                var y = block.CalcMaxY();
                if (y > maxY)
                {
                    maxY = y;
                }
            }

            return maxY;
        }
    }
}

