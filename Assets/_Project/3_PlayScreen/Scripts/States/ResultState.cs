using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.PlayScreen
{
    public class ResultState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private SessionData _sessionData;
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private ResultEffect _resultEffect;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private CustomButton _continueButton;
        [SerializeField] private ContinueState _continueState;
        [SerializeField] private CustomButton _exitButton;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        public void StaticStart()
        {
            _continueButton.AddListener(() =>
            {
                Tonext(_continueState);
            });

            _exitButton.AddListener(() =>
            {
                Tonext(_toTopScreenState);
            });
        }

        public void Enter()
        {
            _continueButton.SetIsListened(true);
            _exitButton.SetIsListened(true);
            ShowResultUI();
            PlayResultEffect();
        }

        private void Tonext(IState nextState)
        {
            _continueButton.SetIsListened(false);
            _exitButton.SetIsListened(false);
            nextState.Enter();
        }

        private void ShowResultUI()
        {
            _resultUI.Show();
            _resultUI.SetMaxHeightText(_sessionData.MaxHeight.value);
            _rotateButton.Hide();
        }

        private void PlayResultEffect()
        {
            var maxHeight = _sessionData.MaxHeight;
            _resultEffect.Play(maxHeight);
        }
    }
}

