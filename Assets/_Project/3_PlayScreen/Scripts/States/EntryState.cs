using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.Systems;
using MT.Audio;
using MT.Blocks;
using MT.Screens.PlayScreen.UI;
using MT.Screens.PlayScreen.Effects;

namespace MT.Screens.PlayScreen.States
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
            AudioManager.Instance.PlayBGM(BGMType.Main);
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
