using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.Screens.TopScreen.States
{
    public class WaitForPlayerActionState : MonoBehaviour, IState
    {
        [SerializeField] private PullTypeButton _playButton;
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
