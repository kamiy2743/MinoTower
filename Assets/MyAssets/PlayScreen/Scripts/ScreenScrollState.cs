using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;
using DG.Tweening;

namespace MT.PlayScreen
{
    public class ScreenScrollState : MonoBehaviour, IState
    {
        [SerializeField] private float _scrollDuration;
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
            ScreenScroll();
        }

        public void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }

        private void ScreenScroll()
        {
            var maxY = Mathf.Max(0, CalcMaxY());
            var cameraTransfrom = Camera.main.transform;
            cameraTransfrom.DOMoveY(maxY, _scrollDuration).OnComplete(() =>
            {
                ToNext();
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

