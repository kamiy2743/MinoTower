using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Util.UI;

namespace MT.Screens.TopScreen.States
{
    public class WaitForPlayerActionState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _playButton;
        [SerializeField] private ToPlayScreenState _toPlayScreenState;
        [SerializeField] private CustomButton _optionButton;
        [SerializeField] private ToOptionScreenState _toOptionScreenState;

        public void StaticStart()
        {
            _playButton.AddListener(() =>
            {
                Tonext(_toPlayScreenState);
            });

            _optionButton.AddListener(() =>
            {
                Tonext(_toOptionScreenState);
            });
        }

        public void Enter()
        {
            _playButton.SetInteractable(true);
            _optionButton.SetInteractable(true);
        }

        private void Tonext(IState nextState)
        {
            _playButton.SetInteractable(false);
            _optionButton.SetInteractable(false);
            nextState.Enter();
        }
    }
}
