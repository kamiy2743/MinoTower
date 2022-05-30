using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.UI;
using MT.Screens.PlayScreen.Systems;
using MT.Util.Effect;

namespace MT.Screens.PlayScreen.States
{
    public class ResultState : MonoBehaviour, IState
    {
        [SerializeField] private PlayData _playData;
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private PaperEffect _paperEffect;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ContinueState _continueState;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        private bool _isActive;

        public void Enter()
        {
            _isActive = true;
            ShowResultUI();
        }

        private void Tonext(IState nextState)
        {
            _isActive = false;
            nextState.Enter();
        }

        void Update()
        {
            if (!_isActive) return;

            if (_resultUI.ContinueButtonClicked)
            {
                Tonext(_continueState);
                return;
            }

            if (_resultUI.ExitButtonClikced)
            {
                Tonext(_toTopScreenState);
                return;
            }
        }

        private void ShowResultUI()
        {
            _resultUI.Show();
            _resultUI.SetMaxHeightText(_playData.MaxHeight.value);

            _rotateButton.Hide();

            var height = _playData.MaxHeight.value;
            var ratio = height * 5f / 100f;
            _paperEffect.Play(ratio);
        }
    }
}

