using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Audio;

namespace MT.Screens.TopScreen.States
{
    public class EntryState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);

            await Fader.Instance.FadeIn(_fadeInDuration);
            AudioManager.Instance.PlayBGM(BGMType.Main);
            var nextState = _nextStateObject.GetComponent<IState>();
            nextState.Enter();
        }
    }
}