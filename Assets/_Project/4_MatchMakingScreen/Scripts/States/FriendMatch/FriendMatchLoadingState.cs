using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.MatchMakingScreen
{
    public class FriendMatchLoadingState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private LoadingUI _loadingUI;
        [SerializeField] private float _fadeDuration;

        [Space(20)]
        [SerializeField] private CustomInput _roomNameInput;

        [Space(20)]
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private FriendMatchSettingState _friendMatchSettingState;

        [Space(20)]
        [SerializeField] private ToMultiPlayScreenState _toMultiPlayScreenState;

        private FriendMatch _friendMatch;

        public void StaticStart()
        {
            _backButton.AddListener(() =>
            {
                OnBackButton();
            });
        }

        public async void EnterAsync()
        {
            await _loadingUI.ShowAsync(_fadeDuration);

            _backButton.SetIsListened(true);

            await CreateMatchAsync();

            OnMatchCompleted();
        }

        private async void ToNext(IState nextState)
        {
            _backButton.SetIsListened(false);

            await _loadingUI.HideAsync(_fadeDuration);

            nextState.EnterAsync();
        }

        private async UniTask CreateMatchAsync()
        {
            _friendMatch = new FriendMatch();
            var roomName = _roomNameInput.Text;
            await _friendMatch.RequestAsync(roomName);
        }

        private void OnMatchCompleted()
        {
            Debug.Log("成功");
            ToNext(_toMultiPlayScreenState);
        }

        private void OnBackButton()
        {
            _friendMatch.Disconnect();
            ToNext(_friendMatchSettingState);
        }
    }
}
