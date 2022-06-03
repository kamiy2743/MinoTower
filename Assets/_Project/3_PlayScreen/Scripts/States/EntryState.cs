using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

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

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);
            Initialize();

            await Fader.Instance.FadeIn(_fadeInDuration);
            AudioPlayer.Instance.PlayBGM(BGMType.Main);
            _nextState.Enter();
        }

        private void Initialize()
        {
            _sessionData.Initialize();
            _blockStore.Initialize();
            _resultUI.Initialize();
            _rotateButton.Initialize();
            _screenScroller.Initialize();
            _resultEffect.Initialize();
        }
    }
}
