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
        [SerializeField] private float _resultUIFadeInDutaion;
        [SerializeField] private ResultEffect _resultEffect;

        [Space(20)]
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private float _rotateButtonFadeOutDuration;

        [Space(20)]
        [SerializeField] private CustomButton _continueButton;
        [SerializeField] private ContinueState _continueState;

        [Space(20)]
        [SerializeField] private CustomButton _exitButton;
        [SerializeField] private SwitchScreenState _toTopScreenState;

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

        public void Enter()
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

            nextState.Enter();
        }

        private async void ShowResultUIAsync()
        {
            _resultUI.SetMaxHeightText(_sessionData.MaxHeight.value);

            await UniTask.WhenAll(
                _resultUI.ShowAsync(_resultUIFadeInDutaion),
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

