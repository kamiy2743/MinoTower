using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class SwitchScreenState : MonoBehaviour, IState
    {
        [SerializeField] private ScreenType _toSwitchType;
        [SerializeField] private float _fadeOutDuration = 0.5f;

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(_fadeOutDuration);
            ScreenSwitcher.Instance.Switch(_toSwitchType);
        }
    }
}
