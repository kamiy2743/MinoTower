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
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private RoomSettingState _roomSettingState;

        [Space(20)]
        [SerializeField] private ToMultiPlayScreenState _toMultiPlayScreenState;

        private FriendMatch _friendMatch;

        public void StaticStart()
        {
            _backButton.AddListener(() =>
            {
                // _friendMatch.Disconnect();
                ToNext(_roomSettingState);
            });
        }

        public async void Enter()
        {
            await _loadingUI.ShowAsync(_fadeDuration);

            _backButton.SetIsListened(true);

            // await CreateMatchAsync();

            // OnMatchCompleted();
        }

        private async void ToNext(IState nextState)
        {
            _backButton.SetIsListened(false);

            await _loadingUI.HideAsync(_fadeDuration);

            nextState.Enter();
        }

        private async UniTask CreateMatchAsync()
        {
            // _friendMatch = new FriendMatch();
            // var roomName = _roomNameInput.Text;
            // await _friendMatch.RequestAsync(roomName);
        }

        private void OnMatchCompleted()
        {
            Debug.Log("成功");
            ToNext(_toMultiPlayScreenState);
        }
    }
}
