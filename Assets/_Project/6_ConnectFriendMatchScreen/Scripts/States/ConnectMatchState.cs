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

        private FriendMatchMaker _matchMaker;

        public void StaticStart()
        {
            _backButton.AddListener(() =>
            {
                ToRoomSettingState();
            });
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(0);
            await _loadingUI.ShowAsync(0);
            await Fader.Instance.FadeInAsync(_fadeDuration);
            _backButton.SetIsListened(true);

            ConnectMatchAsync().Forget();
        }

        private async UniTask ConnectMatchAsync()
        {
            var roomName = _tryConnectRoomNameProvider.GetRoomName();
            Debug.Log("RoomName: " + roomName);

            _matchMaker = new FriendMatchMaker();
            var success = await _matchMaker.TryJoinAsync(roomName);
            if (!success) return;

            Debug.Log("マッチ成功");
            ToMultiPlayScreen();
        }

        private async void ToRoomSettingState()
        {
            _backButton.SetIsListened(false);

            var tasks = new List<UniTask>(2);

            tasks.Add(_loadingUI.HideAsync(_fadeDuration));

            if (_matchMaker != null)
            {
                tasks.Add(_matchMaker.CancelAsync());
            }

            await UniTask.WhenAll(tasks);

            _roomSettingState.Enter();
        }

        private async void ToMultiPlayScreen()
        {
            _backButton.SetIsListened(false);

            await _loadingUI.HideAsync(_fadeDuration);
            _toMultiPlayScreenState.Enter();
        }
    }
}
