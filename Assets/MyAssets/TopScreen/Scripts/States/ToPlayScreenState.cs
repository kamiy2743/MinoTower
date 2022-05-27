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
        [SerializeField] private MT.PlayScreen.PlayScreen _playScreen;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(_fadeOutDuration);
            _topScreenObject.SetActive(false);
            _playScreen.Open();
        }
    }
}
