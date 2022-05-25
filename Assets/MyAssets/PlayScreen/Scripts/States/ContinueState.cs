using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private MainLoopStartState _startState;
        [SerializeField] private Initializer _initializer;
        [SerializeField] private float _fadeDuration;

        public void Enter()
        {
            Fader.Instance.FadeOut(_fadeDuration, () =>
            {
                _initializer.Execute();
                Fader.Instance.FadeIn(_fadeDuration, () =>
                {
                    _startState.Enter();
                });
            });
        }
    }
}
