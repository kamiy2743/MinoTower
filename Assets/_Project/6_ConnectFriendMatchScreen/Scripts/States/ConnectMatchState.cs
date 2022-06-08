using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.ConnectFriendMatchScreen
{
    public class ConnectMatchState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private LoadingUI _loadingUI;
        [SerializeField] private float _fadeDuration;

        [Space(20)]
        [SerializeField] private TryConnectRoomNameProvider _tryConnectRoomNameProvider;

        [Space(20)]
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private RoomSettingState _roomSettingState;

        [Space(20)]
        [SerializeField] private SwitchScreenState _toMultiPlayScreenState;

        private FriendMatch _friendMatch;

        public void StaticStart()
        {
            _backButton.AddListener(async () =>
            {
                if (_friendMatch != null)
                {
                    await _friendMatch.Disconnect();
                }
                ToNext(_roomSettingState);
            });
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(0);
            await _loadingUI.ShowAsync(0);
            await Fader.Instance.FadeInAsync(_fadeDuration);

            _backButton.SetIsListened(true);

            var success = await ConnectMatchAsync();

            if (success)
            {
                Debug.Log("マッチ成功");
                ToNext(_toMultiPlayScreenState);
            }
        }

        private async void ToNext(IState nextState)
        {
            _backButton.SetIsListened(false);

            await _loadingUI.HideAsync(_fadeDuration);

            nextState.Enter();
        }

        /// <returns>success</returns>
        private async UniTask<bool> ConnectMatchAsync()
        {
            var roomName = _tryConnectRoomNameProvider.GetRoomName();
            Debug.Log("RoomName: " + roomName);

            if (_friendMatch != null)
            {
                await _friendMatch.Disconnect();
            }

            _friendMatch = new FriendMatch();
            var success = await _friendMatch.ConnectAsync(roomName);

            return success;
        }
    }
}