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

        public void Enter()
        {
            Fader.Instance.FadeOut(0);
            _topScreenObject.SetActive(true);
            Fader.Instance.FadeIn(_fadeInDuration, () =>
            {
                var nextState = _nextStateObject.GetComponent<IState>();
                nextState.Enter();
            });
        }
    }
}
