using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.Systems;
using MT.Blocks;
using MT.Screens.PlayScreen.UI;

namespace MT.Screens.PlayScreen.States
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private EntryState _entryState;
        [SerializeField] private float _fadeDuration;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(_fadeDuration);
            _entryState.Enter();
        }
    }
}
