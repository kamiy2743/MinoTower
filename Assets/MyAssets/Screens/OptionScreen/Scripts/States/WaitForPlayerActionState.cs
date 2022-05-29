using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Util.UI;

namespace MT.Screens.OptionScreen.States
{
    public class WaitForPlayerActionState : MonoBehaviour, IState
    {
        [SerializeField] private PullTypeButton _backButton;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        private bool _isActive;

        public void Enter()
        {
            _isActive = true;
        }

        private void Tonext()
        {
            _isActive = false;
            _toTopScreenState.Enter();
        }

        void Update()
        {
            if (!_isActive) return;

            if (_backButton.IsClicked())
            {
                Tonext();
                return;
            }
        }
    }
}
