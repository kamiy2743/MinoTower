using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.ConnectFriendMatchScreen
{
    public class ConnectMatchState : MonoBehaviour, IStaticStart
    {
        [SerializeField] private LoadingUI _loadingUI;
        [SerializeField] private float _fadeInDuration;

        [Space(20)]
        [SerializeField] private FriendMatchRoomNameAccessor _friendMatchRoomNameAccessor;

        [Space(20)]
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private RoomSettingState _roomSettingState;
        [SerializeField] private float _fadeOutDuration;

        [Space(20)]
        [SerializeField] private SwitchScreenHelper _toMultiPlayScreen;

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
            await _loadingUI.ShowAsync(_fadeInDuration);
            _backButton.SetIsListened(true);

            ConnectMatchAsync().Forget();
        }

        private void OnExit()
        {
            _backButton.SetIsListened(false);
        }

        private async UniTask ConnectMatchAsync()
        {
            var roomName = _friendMatchRoomNameAccessor.Get();
            Debug.Log("RoomName: " + roomName);

            _matchMaker = new FriendMatchMaker();
            var success = await _matchMaker.JoinRoomAsync(roomName);
            if (!success) return;

            Debug.Log("マッチ成功");
            ToMultiPlayScreen();
        }

        private async void ToRoomSettingState()
        {
            OnExit();

            var tasks = new List<UniTask>();

            tasks.Add(_loadingUI.HideAsync(_fadeOutDuration));

            if (_matchMaker != null)
            {
                tasks.Add(_matchMaker.CancelAsync());
            }

            await UniTask.WhenAll(tasks);

            _friendMatchRoomNameAccessor.SetEmpty();
            _roomSettingState.Enter();
        }

        private void ToMultiPlayScreen()
        {
            OnExit();
            _toMultiPlayScreen.Switch();
        }
    }
}
