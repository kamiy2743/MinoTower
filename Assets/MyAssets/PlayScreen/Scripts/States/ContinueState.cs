using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private MainLoopStartState _startState;
        [SerializeField] private PlayScreenInitializer _initializer;
        [SerializeField] private float _fadeDuration;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(_fadeDuration);
            _initializer.Execute();
            await Fader.Instance.FadeIn(_fadeDuration);
            _startState.Enter();
        }
    }
}
