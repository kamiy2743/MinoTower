using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.SelectMatchScreen
{
    public class FriendMatchSettingState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private FriendMatchUI _friendMatchUI;
        [SerializeField] private float _fadeDuration;

        [Space(20)]
        [SerializeField] private CustomInput _roomNameInput;
        [SerializeField] private CustomButton _decideButton;
        [SerializeField] private FriendMatchLoadingState _friendMatchLoadingState;

        [Space(20)]
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private SelectMatchState selectMatchState;

        public void StaticStart()
        {
            _decideButton.AddListener(() =>
            {
                OnDecidedButton();
            });

            _backButton.AddListener(() =>
            {
                OnBackButton();
            });
        }

        public async void Enter()
        {
            await _friendMatchUI.ShowAsync(_fadeDuration);

            _decideButton.SetIsListened(true);
            _backButton.SetIsListened(true);
        }

        private async void ToNextAsync(IState nextState)
        {
            _decideButton.SetIsListened(false);
            _backButton.SetIsListened(false);

            await _friendMatchUI.HideAsync(_fadeDuration);

            nextState.Enter();
        }

        private void OnDecidedButton()
        {
            // TODO 状態をUIに保持してる
            if (_roomNameInput.IsEmpty())
            {
                return;
            }

            ToNextAsync(_friendMatchLoadingState);
        }

        private void OnBackButton()
        {
            ToNextAsync(selectMatchState);
        }
    }
}
