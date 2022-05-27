using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.Screens.TopScreen.States
{
    public class EnterState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;
        [SerializeField] private Initializer _initializer;

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
