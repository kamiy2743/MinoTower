using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;
using MT.Screens.PlayScreen.Systems;

namespace MT.Screens.PlayScreen.States
{
    public class ScreenScrollState : MonoBehaviour, IState
    {
        [SerializeField] private ScreenScroller _screenScroller;
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

        private async void ScreenScroll()
        {
            var maxY = _blockStore.GetMaxY();
            await _screenScroller.SetScroll(new ScrollAmount(maxY), _scrollDuration);
            ToNext();
        }
    }
}

