using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Util.UI;

namespace MT.Screens.OptionScreen.States
{
    public class WaitForPlayerActionState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        private bool _isActive;

        public void StaticStart()
        {
            _backButton.AddListener(() =>
            {
                Tonext();
            });
        }

        public void Enter()
        {
            _backButton.SetInteractable(true);
        }

        private void Tonext()
        {
            _backButton.SetInteractable(false);
            _toTopScreenState.Enter();
        }
    }
}
