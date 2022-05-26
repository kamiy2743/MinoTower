using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;
using DG.Tweening;

namespace MT.PlayScreen.States
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
        }

        public void Enter()
        {
            ScreenScroll();
        }

        public void ToNext()
        {
            _nextState.Enter();
        }

        private void ScreenScroll()
        {
            var maxHeight = _blockStore.CalcMaxHeight();
            ScreenScroller.Instance.SetScroll(new ScrollAmount(maxHeight.value), _scrollDuration, () =>
            {
                ToNext();
            });
        }
    }
}

