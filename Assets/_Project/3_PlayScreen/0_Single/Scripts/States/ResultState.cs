using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen.Single
{
    public class ResultState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private SessionData _sessionData;

        [Space(20)]
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private ResultEffect _resultEffect;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private float _fadeDuration;

        [Space(20)]
        [SerializeField] private CustomButton _continueButton;
        [SerializeField] private ContinueState _continueState;

        [Space(20)]
        [SerializeField] private CustomButton _exitButton;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        public void StaticStart()
        {
            _continueButton.AddListener(() =>
            {
                ToNext(_continueState);
            });

            _exitButton.AddListener(() =>
            {
                ToNext(_toTopScreenState);
            });
        }

        public void EnterAsync()
        {
            _continueButton.SetIsListened(true);
            _exitButton.SetIsListened(true);

            ShowResultUIAsync();
            PlayResultEffect();
        }

        private void ToNext(IState nextState)
        {
            _continueButton.SetIsListened(false);
            _exitButton.SetIsListened(false);

            nextState.EnterAsync();
        }

        private async void ShowResultUIAsync()
        {
            _resultUI.ShowAsync();
            _resultUI.SetMaxHeightText(_sessionData.MaxHeight.value);

            await _rotateButton.HideAsync(_fadeDuration);
        }

        private void PlayResultEffect()
        {
            var maxHeight = _sessionData.MaxHeight;
            _resultEffect.Play(maxHeight);
        }
    }
}

