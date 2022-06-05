using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Single
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private RandomProvider _randomProvider;
        [SerializeField] private SessionData _sessionData;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ScreenScroller _screenScroller;
        [SerializeField] private ResultEffect _resultEffect;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void EnterAsync()
        {
            await Fader.Instance.FadeOutAsync(0);
            await InitializeAsync();

            await Fader.Instance.FadeInAsync(_fadeInDuration);
            _nextState.EnterAsync();
        }

        private async UniTask InitializeAsync()
        {
            _randomProvider.RandomForBlock = new CustomRandom();
            _sessionData.Initialize();
            _blockStore.Initialize();
            _resultUI.Initialize();
            _resultEffect.Initialize();
            await _rotateButton.ShowAsync(0);
            await _screenScroller.InitializeAsync();
        }
    }
}
