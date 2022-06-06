using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeDuration;
        [SerializeField] private ToConnectFriendMatchScreenState _toConnectFriendMatchScreenState;

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(_fadeDuration);
            _toConnectFriendMatchScreenState.Enter();
        }
    }
}
