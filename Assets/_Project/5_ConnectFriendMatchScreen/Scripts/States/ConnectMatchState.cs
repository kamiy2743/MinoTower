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
        [SerializeField] private ToMultiPlayScreenState _toMultiPlayScreenState;

        private FriendMatch _friendMatch;

        public void StaticStart()
        {
            _backButton.AddListener(() =>
            {
                _friendMatch?.Disconnect();
                ToNext(_roomSettingState);
            });
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(0);
            await _loadingUI.ShowAsync(0);
            await Fader.Instance.FadeInAsync(_fadeDuration);

            _backButton.SetIsListened(true);

            await ConnectMatchAsync();

            OnMatchCompleted();
        }

        private async void ToNext(IState nextState)
        {
            _backButton.SetIsListened(false);

            await _loadingUI.HideAsync(_fadeDuration);

            nextState.Enter();
        }

        private async UniTask ConnectMatchAsync()
        {
            var roomName = _tryConnectRoomNameProvider.GetRoomName();
            Debug.Log("RoomName: " + roomName);

            _friendMatch = new FriendMatch();
            await _friendMatch.RequestAsync(roomName);
        }

        private void OnMatchCompleted()
        {
            Debug.Log("成功");
            ToNext(_toMultiPlayScreenState);
        }
    }
}
