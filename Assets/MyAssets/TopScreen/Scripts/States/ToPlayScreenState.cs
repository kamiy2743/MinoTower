using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace Mt.TopScreen.States
{
    public class ToPlayScreenState : MonoBehaviour, IState
    {
        [SerializeField] private GameObject _topScreenObject;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private MT.PlayScreen.States.EnterState _playScreenEnterState;

        public void Enter()
        {
            Fader.Instance.FadeOut(_fadeOutDuration, () =>
            {
                _topScreenObject.SetActive(false);
                _playScreenEnterState.Enter();
            });
        }
    }
}
