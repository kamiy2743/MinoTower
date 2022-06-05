using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.TopScreen
{
    public class ToSinglePlayScreenState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeOutDuration;

        public async void EnterAsync()
        {
            await Fader.Instance.FadeOutAsync(_fadeOutDuration);
            ScreenSwitcher.Instance.Switch(ScreenType.SinglePlay);
        }
    }
}
