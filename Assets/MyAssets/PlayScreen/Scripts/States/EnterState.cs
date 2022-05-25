using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class EnterState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _playScreenObject;
        [SerializeField] private GameObject _nextStateObject;
        [SerializeField] private Initializer _initializer;

        public void Enter()
        {
            Fader.Instance.FadeOut(0);
            _playScreenObject.SetActive(true);
            _initializer.Execute();

            Fader.Instance.FadeIn(_fadeInDuration, () =>
            {
                var nextState = _nextStateObject.GetComponent<IState>();
                nextState.Enter();
            });
        }
    }
}
