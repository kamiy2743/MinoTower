using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Single
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeDuration;
        [SerializeField] private EntryState _entryState;

        public async void EnterAsync()
        {
            await Fader.Instance.FadeOutAsync(_fadeDuration);
            _entryState.EnterAsync();
        }
    }
}
