using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;

namespace MT.PlayScreen.States
{
    public class ScreenScrollState : MonoBehaviour, IState
    {
        [SerializeField] private float _scrollDuration;
        [SerializeField] private PlayData _playData;
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
            var maxHeightValue = _playData.MaxHeight.value;
            await ScreenScroller.Instance.SetScroll(new ScrollAmount(maxHeightValue), _scrollDuration);
            ToNext();
        }
    }
}

