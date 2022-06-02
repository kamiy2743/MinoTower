using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Audio;

namespace MT.Screens.TopScreen.States
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);

            await Fader.Instance.FadeIn(_fadeInDuration);
            AudioManager.Instance.PlayBGM(BGMType.Main);
            _nextState.Enter();
        }
    }
}
