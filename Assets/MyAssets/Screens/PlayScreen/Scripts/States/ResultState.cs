using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.UI;

namespace MT.Screens.PlayScreen.States
{
    public class ResultState : MonoBehaviour, IState
    {
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ContinueState _continueState;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        private bool _isActive;

        public void Enter()
        {
            _isActive = true;
            _resultUI.Show();
            _rotateButton.Hide();
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
    }
}

