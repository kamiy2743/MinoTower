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
        [SerializeField] private BlockStore _blockStore;
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
            var maxHeight = _blockStore.CalcMaxHeight();
            var cameraTransfrom = Camera.main.transform;
            cameraTransfrom.DOMoveY(maxHeight.value, _scrollDuration).OnComplete(() =>
            {
                ToNext();
            });
        }
    }
}

