using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ToTopScreenState : MonoBehaviour, IState
    {
        [SerializeField] private PlayScreen _playScreen;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private MT.TopScreen.States.EnterState _topScreenEnterState;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(_fadeOutDuration);
            _playScreen.Close();
            _topScreenEnterState.Enter();
        }
    }
}
