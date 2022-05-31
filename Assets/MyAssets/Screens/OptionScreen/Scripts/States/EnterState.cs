using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.OptionScreen.Systems;

namespace MT.Screens.OptionScreen.States
{
    public class EnterState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [SerializeField] private AudioSettingApplier _audioSettingApplier;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);

            await Fader.Instance.FadeIn(_fadeInDuration);
            var nextState = _nextStateObject.GetComponent<IState>();
            nextState.Enter();
        }

        public void Initialize()
        {
            _audioSettingApplier.Initialize();
        }
    }
}
