using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.ConnectFriendMatchScreen
{
    public class RoomSettingState : MonoBehaviour, IStaticStart
    {
        [SerializeField] private RoomSettingUI _roomSettingUI;
        [SerializeField] private float _fadeInDuration;

        [Space(20)]
        [SerializeField] private CustomInput _roomNameInput;
        [SerializeField] private FriendMatchRoomNameAccessor _friendMatchRoomNameAccessor;
        [SerializeField] private CustomButton _decideButton;
        [SerializeField] private ConnectMatchState _connectMatchState;
        [SerializeField] private float _fadeOutDuration;

        [Space(20)]
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private SwitchScreenHelper _toSelectMatchScreen;

        public void StaticStart()
        {
            _decideButton.AddListener(() =>
            {
                var success = SetRoomName();
                if (success) ToConnectMatchState();
            });

            _backButton.AddListener(() =>
            {
                ToSelectMatchScreen();
            });
        }

        public async void Enter()
        {
            await _roomSettingUI.ShowAsync(_fadeInDuration);

            _decideButton.SetIsListened(true);
            _backButton.SetIsListened(true);
        }

        private void OnExit()
        {
            _decideButton.SetIsListened(false);
            _backButton.SetIsListened(false);
        }

        /// <returns>Success</returns>
        private bool SetRoomName()
        {
            if (_roomNameInput.IsEmpty())
            {
                return false;
            }

            _friendMatchRoomNameAccessor.Set(_roomNameInput.Text);
            return true;
        }

        private async void ToConnectMatchState()
        {
            OnExit();
            await _roomSettingUI.HideAsync(_fadeOutDuration);
            _connectMatchState.Enter();
        }

        private void ToSelectMatchScreen()
        {
            OnExit();
            _toSelectMatchScreen.Switch();
        }
    }
}
