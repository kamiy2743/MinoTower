using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Single
{
    public class ResultState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private SessionData _sessionData;

        [Space(20)]
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private float _resultUIFadeInDuration;
        [SerializeField] private ResultEffect _resultEffect;

        [Space(20)]
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private float _rotateButtonFadeOutDuration;

        [Space(20)]
        [SerializeField] private CustomButton _continueButton;
        [SerializeField] private ContinueState _continueState;

        [Space(20)]
        [SerializeField] private CustomButton _exitButton;
        [SerializeField] private SwitchScreenHelper _toTopScreen;

        public void StaticStart()
        {
            _continueButton.AddListener(() =>
            {
                ToContinueState();
            });

            _exitButton.AddListener(() =>
            {
                ToTopScreen();
            });
        }

        public async void Enter()
        {
            PlayResultEffect();
            await ShowResultUIAsync();

            _continueButton.SetIsListened(true);
            _exitButton.SetIsListened(true);
        }

        private void OnExit()
        {
            _continueButton.SetIsListened(false);
            _exitButton.SetIsListened(false);
        }

        private void ToContinueState()
        {
            OnExit();
            _continueState.Enter();
        }

        private async void ToTopScreen()
        {
            OnExit();
            await PhotonUtil.LeaveRoomAsync();
            _toTopScreen.Switch();
        }

        private async UniTask ShowResultUIAsync()
        {
            _resultUI.SetMaxHeightText(_sessionData.MaxHeight.value);

            await UniTask.WhenAll(
                _resultUI.ShowAsync(_resultUIFadeInDuration),
                _rotateButton.HideAsync(_rotateButtonFadeOutDuration)
            );
        }

        private void PlayResultEffect()
        {
            var maxHeight = _sessionData.MaxHeight;
            _resultEffect.Play(maxHeight);
        }
    }
}

