using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.OptionScreen
{
    public class ToTopScreenState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeOutDuration;

        public async void EnterAsync()
        {
            await Fader.Instance.FadeOutAsync(_fadeOutDuration);
            ScreenSwitcher.Instance.Switch(ScreenType.Top);
        }
    }
}
