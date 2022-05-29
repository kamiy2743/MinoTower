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
        [SerializeField] private Initializer _initializer;
        [SerializeField] private GameObject _nextStateObject;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);
            _initializer.Execute();

            await Fader.Instance.FadeIn(_fadeInDuration);
            var nextState = _nextStateObject.GetComponent<IState>();
            nextState.Enter();
        }
    }
}
