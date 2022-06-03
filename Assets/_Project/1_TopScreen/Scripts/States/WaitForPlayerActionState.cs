using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.TopScreen
{
    public class WaitForPlayerActionState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _playButton;
        [SerializeField] private ToPlayScreenState _toPlayScreenState;
        [Space(20)]
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
            _playButton.SetIsListened(true);
            _optionButton.SetIsListened(true);
        }

        private void Tonext(IState nextState)
        {
            _playButton.SetIsListened(false);
            _optionButton.SetIsListened(false);
            nextState.Enter();
        }
    }
}
