using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Util.UI;

namespace MT.Screens.TopScreen.States
{
    public class WaitForPlayerActionState : MonoBehaviour, IState
    {
        [SerializeField] private PullTypeButton _playButton;
        [SerializeField] private ToPlayScreenState _toPlayScreenState;
        [SerializeField] private PullTypeButton _optionButton;
        [SerializeField] private ToOptionScreenState _toOptionScreenState;

        private bool _isActive;

        public void Enter()
        {
            _isActive = true;
        }

        private void Tonext(IState nextState)
        {
            _isActive = false;
            nextState.Enter();
        }

        void Update()
        {
            if (!_isActive) return;

            if (_playButton.IsClicked())
            {
                Tonext(_toPlayScreenState);
                return;
            }

            if (_optionButton.IsClicked())
            {
                Tonext(_toOptionScreenState);
                return;
            }
        }
    }
}
