using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.TopScreen
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void EnterAsync()
        {
            await Fader.Instance.FadeOutAsync(0);
            await Fader.Instance.FadeInAsync(_fadeInDuration);
            _nextState.EnterAsync();
        }
    }
}
