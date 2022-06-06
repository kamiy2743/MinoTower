using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Pun2Task;

namespace MT.ConnectFriendMatchScreen
{
    public class EntryState : MonoBehaviour, IState
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private RoomSettingState _roomSettingState;
        [SerializeField] private ConnectMatchState _connectMatchState;

        [Space(20)]
        [SerializeField] private TryConnectRoomNameProvider _tryConnectRoomNameProvider;

        [Header("初期化対象")]
        [SerializeField] private RoomSettingUI _roomSettingUI;
        [SerializeField] private LoadingUI _loadingUI;

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(0);
            await InitializeAsync();

            if (_tryConnectRoomNameProvider.IsEmpty())
            {
                _roomSettingState.Enter();
            }
            else
            {
                _connectMatchState.Enter();
            }
        }

        private async UniTask InitializeAsync()
        {
            await _roomSettingUI.HideAsync(0);
            await _loadingUI.HideAsync(0);
        }
    }
}
