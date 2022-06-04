using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.MatchMakingScreen
{
    public class FriendMatchState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private LoadingUI _loadingUI;
        [SerializeField] private float _loadingUIFadeDuration;

        [Space(20)]
        [SerializeField] private FriendMatchUI _friendMatchUI;
        [SerializeField] private float _friendMatchUIFadeDuration;

        [Space(20)]
        [SerializeField] private CustomInput _roomNameInput;
        [SerializeField] private CustomButton _decideButton;

        [Space(20)]
        [SerializeField] private CustomButton _backToSelectMatchStateButton;
        [SerializeField] private SelectMatchState selectMatchState;

        [Space(20)]
        [SerializeField] private CustomButton _backToInputButton;

        private FriendMatch _friendMatch;

        public void StaticStart()
        {
            _decideButton.AddListener(() => OnDecidedButton());

            _backToSelectMatchStateButton.AddListener(() =>
            {
                ToNext(selectMatchState);
            });

            _backToInputButton.AddListener(() => BackToInput());
        }

        public async void Enter()
        {
            _decideButton.SetIsListened(true);
            _backToSelectMatchStateButton.SetIsListened(true);

            await _friendMatchUI.Show(_friendMatchUIFadeDuration);
        }

        private async void ToNext(IState nextState)
        {
            _decideButton.SetIsListened(false);
            _backToSelectMatchStateButton.SetIsListened(false);
            _backToInputButton.SetIsListened(false);

            await _friendMatchUI.Hide(_friendMatchUIFadeDuration);

            nextState.Enter();
        }

        private async void OnDecidedButton()
        {
            if (_roomNameInput.IsEmpty())
            {
                return;
            }

            _decideButton.SetIsListened(false);

            await _friendMatchUI.Hide(_friendMatchUIFadeDuration);
            await _loadingUI.Show(_loadingUIFadeDuration);
            _backToInputButton.SetIsListened(true);

            var roomName = _roomNameInput.Text;
            await TryFriendMatch(roomName);

            Debug.Log("成功");
            _backToInputButton.SetIsListened(false);
            await _loadingUI.Hide(_loadingUIFadeDuration);
        }

        private async void BackToInput()
        {
            _friendMatch.Disconnect();

            _backToInputButton.SetIsListened(false);
            await _loadingUI.Hide(_loadingUIFadeDuration);

            await _friendMatchUI.Show(_friendMatchUIFadeDuration);
            _decideButton.SetIsListened(true);
            _backToSelectMatchStateButton.SetIsListened(true);
        }

        private async UniTask TryFriendMatch(string roomName)
        {
            _friendMatch = new FriendMatch();
            await _friendMatch.RequestAsync(roomName);
        }
    }
}
