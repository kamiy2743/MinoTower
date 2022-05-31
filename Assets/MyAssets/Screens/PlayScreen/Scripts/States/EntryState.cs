using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.Systems;
using MT.Audio;
using MT.Blocks;
using MT.Screens.PlayScreen.UI;

namespace MT.Screens.PlayScreen.States
{
    public class EntryState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [SerializeField] private PlayData _playData;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ScreenScroller _screenScroller;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);
            Initialize();

            await Fader.Instance.FadeIn(_fadeInDuration);
            AudioManager.Instance.PlayBGM(BGMType.Main);
            // TODO Awakeに持ってく
            var nextState = _nextStateObject.GetComponent<IState>();
            nextState.Enter();
        }

        private void Initialize()
        {
            _playData.Initialize();
            _blockStore.Initialize();
            _resultUI.Initialize();
            _rotateButton.Initialize();
            _screenScroller.Initialize();
        }
    }
}
