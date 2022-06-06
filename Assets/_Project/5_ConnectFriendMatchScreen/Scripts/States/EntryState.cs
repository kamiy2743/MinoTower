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

        [Header("初期化対象")]
        [SerializeField] private RoomSettingUI _roomSettingUI;
        [SerializeField] private LoadingUI _loadingUI;

        public async void Enter()
        {
            await Fader.Instance.FadeOutAsync(0);
            Initialize();

            await Pun2TaskNetwork.ConnectUsingSettingsAsync();

            if (false)
            {
                _connectMatchState.Enter();
            }
            else
            {
                _roomSettingState.Enter();
            }
        }

        private async void Initialize()
        {
            await _roomSettingUI.HideAsync(0);
            await _loadingUI.HideAsync(0);
        }
    }
}
