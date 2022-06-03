using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
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