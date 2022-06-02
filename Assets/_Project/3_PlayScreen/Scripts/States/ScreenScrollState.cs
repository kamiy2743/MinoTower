using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class ScreenScrollState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private ScreenScroller _screenScroller;
        [SerializeField] private float _scrollDuration;
        [SerializeField] private BlocksMaxYProvider _blocksMaxYProvider;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
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
            var maxY = _blocksMaxYProvider.MaxY();
            await _screenScroller.SetScroll(new ScrollAmount(maxY), _scrollDuration);
            ToNext();
        }
    }
}

