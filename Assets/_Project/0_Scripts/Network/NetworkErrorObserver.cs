using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cysharp.Threading.Tasks;

namespace MT
{
    public class NetworkErrorObserver : MonoBehaviourPunCallbacks, IStaticAwake, IStaticStart
    {
        [SerializeField] private CommonUI _UI;
        [SerializeField] private float _fadeInDuration;

        [Space(20)]
        [SerializeField] private CustomButton _toTitleButton;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private SwitchScreenHelper _toTitleScreen;

        private bool _isListened = false;

        public static NetworkErrorObserver Instance => _instance;
        private static NetworkErrorObserver _instance;

        public void StaticAwake()
        {
            _instance = this;
        }

        public void StaticStart()
        {
            _toTitleButton.AddListener(() =>
            {
                ToTitleScreen();
            });
        }

        public void Initialize()
        {
            _UI.HideAsync(0).Forget();
        }

        public void SetIsListened(bool value)
        {
            _isListened = value;
        }

        public override async void OnPlayerLeftRoom(Player otherPlayer)
        {
            if (!_isListened) return;

            SetIsListened(false);

            await _UI.ShowAsync(_fadeInDuration);
            _toTitleButton.SetIsListened(true);
        }

        private async void ToTitleScreen()
        {
            _toTitleButton.SetIsListened(false);

            await UniTask.WhenAll(
                Fader.Instance.FadeOutAsync(_fadeOutDuration),
                PhotonUtil.DisconnectAsync());

            _UI.HideAsync(0).Forget();

            _toTitleScreen.Switch();
        }
    }
}
