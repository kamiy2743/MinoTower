using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;

namespace MT.Screens.PlayScreen.States
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

        private async void ScreenScroll()
        {
            var maxY = _blockStore.GetMaxY();
            await ScreenScroller.Instance.SetScroll(new ScrollAmount(maxY), _scrollDuration);
            ToNext();
        }
    }
}

