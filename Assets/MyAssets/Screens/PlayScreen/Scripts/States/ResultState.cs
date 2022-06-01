using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.UI;
using MT.Screens.PlayScreen.Systems;
using MT.Screens.PlayScreen.Effects;
using MT.Util.UI;

namespace MT.Screens.PlayScreen.States
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
            _continueButton.SetInteractable(true);
            _exitButton.SetInteractable(true);
            ShowResultUI();
            PlayResultEffect();
        }

        private void Tonext(IState nextState)
        {
            _continueButton.SetInteractable(false);
            _exitButton.SetInteractable(false);
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

