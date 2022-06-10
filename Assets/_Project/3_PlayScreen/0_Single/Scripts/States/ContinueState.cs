using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Single
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private EntryState _entryState;

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(_fadeOutDuration);
            _entryState.Enter();
        }
    }
}
