using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT
{
    public class ToMatchMakingScreenState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeOutDuration;

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(_fadeOutDuration);
            ScreenSwitcher.Instance.Switch(ScreenType.MatchMaking);
        }
    }
}
