using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen
{
    public class ScreenScrollState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private BlocksMaxYProvider _blocksMaxYProvider;

        [Space(20)]
        [SerializeField] private ScreenScroller _screenScroller;
        [SerializeField] private float _scrollDuration;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void EnterAsync()
        {
            await ScreenScrollAsync();
            ToNext();
        }

        public void ToNext()
        {
            _nextState.EnterAsync();
        }

        private async UniTask ScreenScrollAsync()
        {
            var maxY = _blocksMaxYProvider.MaxY();
            await _screenScroller.SetScrollAsync(new ScrollAmount(maxY), _scrollDuration);
        }
    }
}

