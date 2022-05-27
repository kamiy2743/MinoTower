using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using UnityEngine.UI;
using MT.Screens.TopScreen.UI;

namespace MT.Screens.TopScreen.States
{
    public class WaitForPlayerActionState : MonoBehaviour, IState
    {
        [SerializeField] private PlayButton _playButton;
        [SerializeField] private ToPlayScreenState _toPlayScreenState;

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
        }
    }
}
