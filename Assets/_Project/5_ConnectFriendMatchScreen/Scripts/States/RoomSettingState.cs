using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.ConnectFriendMatchScreen
{
    public class RoomSettingState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private RoomSettingUI _roomSettingUI;
        [SerializeField] private float _fadeDuration;

        [Space(20)]
        [SerializeField] private CustomInput _roomNameInput;
        [SerializeField] private CustomButton _decideButton;
        [SerializeField] private ConnectMatchState _connectMatchState;

        [Space(20)]
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private ToSelectMatchScreenState _toSelectMatchScreenState;

        public void StaticStart()
        {
            _decideButton.AddListener(() =>
            {
                OnDecidedButton();
            });

            _backButton.AddListener(() =>
            {
                ToNextAsync(_toSelectMatchScreenState);
            });
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(0);
            await _roomSettingUI.ShowAsync(0);
            await Fader.Instance.FadeInAsync(_fadeDuration);

            _decideButton.SetIsListened(true);
            _backButton.SetIsListened(true);
        }

        private async void ToNextAsync(IState nextState)
        {
            _decideButton.SetIsListened(false);
            _backButton.SetIsListened(false);

            await _roomSettingUI.HideAsync(_fadeDuration);
            nextState.Enter();
        }

        private void OnDecidedButton()
        {
            if (_roomNameInput.IsEmpty())
            {
                return;
            }

            // TODO TryConnectRoomName設定

            ToNextAsync(_connectMatchState);
        }
    }
}
