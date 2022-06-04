using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.MatchMakingScreen
{
    public class ToTopScreenState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeOutDuration;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(_fadeOutDuration);
            ScreenSwitcher.Instance.Switch(ScreenType.Top);
        }
    }
}
