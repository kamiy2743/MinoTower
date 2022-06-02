using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.Screens.TopScreen.States
{
    public class ToPlayScreenState : MonoBehaviour, IState
    {
        [SerializeField] private TopScreen _topScreen;
        [SerializeField] private MT.Screens.PlayScreen.PlayScreen _playScreen;
        [SerializeField] private float _fadeOutDuration;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(_fadeOutDuration);
            _topScreen.Close();
            _playScreen.Open();
        }
    }
}
