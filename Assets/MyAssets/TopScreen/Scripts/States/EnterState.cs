using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.TopScreen.States
{
    public class EnterState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _topScreenObject;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            Fader.Instance.FadeOut(0);
            _topScreenObject.SetActive(true);
            Fader.Instance.FadeIn(_fadeInDuration, () =>
            {
                _nextState.Enter();
            });
        }
    }
}
