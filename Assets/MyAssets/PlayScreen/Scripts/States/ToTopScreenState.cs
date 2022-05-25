using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ToTopScreenState : MonoBehaviour, IState
    {
        [SerializeField] private GameObject _playScreenObject;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private MT.TopScreen.States.EnterState _topScreenEnterState;

        public void Enter()
        {
            Fader.Instance.FadeOut(_fadeOutDuration, () =>
            {
                _playScreenObject.SetActive(false);
                _topScreenEnterState.Enter();
            });
        }
    }
}
