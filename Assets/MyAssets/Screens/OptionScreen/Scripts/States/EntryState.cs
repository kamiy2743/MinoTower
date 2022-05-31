using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.OptionScreen.Systems;

namespace MT.Screens.OptionScreen.States
{
    public class EntryState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [SerializeField] private AudioSettingApplier _audioSettingApplier;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);
            Initialize();

            await Fader.Instance.FadeIn(_fadeInDuration);
            var nextState = _nextStateObject.GetComponent<IState>();
            nextState.Enter();
        }

        private void Initialize()
        {
            _audioSettingApplier.Initialize();
        }
    }
}
