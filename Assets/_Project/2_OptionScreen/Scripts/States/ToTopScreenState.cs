using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.OptionScreen
{
    public class ToTopScreenState : MonoBehaviour, IState
    {
        [SerializeField] private OptionScreen _optionScreen;
        [SerializeField] private MT.TopScreen.TopScreen _topScreen;
        [SerializeField] private float _fadeOutDuration;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(_fadeOutDuration);
            _optionScreen.Close();
            _topScreen.Open();
        }
    }
}
