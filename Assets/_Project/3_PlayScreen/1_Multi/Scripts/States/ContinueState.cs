using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Multi
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeDuration;

        public async void EnterAsync()
        {
            await Fader.Instance.FadeOutAsync(_fadeDuration);
        }
    }
}
