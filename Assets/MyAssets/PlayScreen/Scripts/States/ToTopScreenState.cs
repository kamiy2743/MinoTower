using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ToTopScreenState : MonoBehaviour, IState
    {
        [SerializeField] private PlayScreen _playScreen;
        [SerializeField] private MT.TopScreen.TopScreen _topScreen;
        [SerializeField] private float _fadeOutDuration;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(_fadeOutDuration);
            _playScreen.Close();
            _topScreen.Open();
        }
    }
}
