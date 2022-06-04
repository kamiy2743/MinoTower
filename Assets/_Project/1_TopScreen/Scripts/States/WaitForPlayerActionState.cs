using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.TopScreen
{
    public class WaitForPlayerActionState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _singlePlayButton;
        [SerializeField] private ToSinglePlayScreenState _toSinglePlayScreenState;

        [Space(20)]
        [SerializeField] private CustomButton _multiPlayButton;
        [SerializeField] private ToMultiPlayScreenState _toMultiPlayScreenState;

        [Space(20)]
        [SerializeField] private CustomButton _optionButton;
        [SerializeField] private ToOptionScreenState _toOptionScreenState;

        public void StaticStart()
        {
            _singlePlayButton.AddListener(() =>
            {
                Tonext(_toSinglePlayScreenState);
            });

            _multiPlayButton.AddListener(() =>
            {
                Tonext(_toMultiPlayScreenState);
            });

            _optionButton.AddListener(() =>
            {
                Tonext(_toOptionScreenState);
            });
        }

        public void Enter()
        {
            _singlePlayButton.SetIsListened(true);
            _multiPlayButton.SetIsListened(true);
            _optionButton.SetIsListened(true);
        }

        private void Tonext(IState nextState)
        {
            _singlePlayButton.SetIsListened(false);
            _multiPlayButton.SetIsListened(false);
            _optionButton.SetIsListened(false);

            nextState.Enter();
        }
    }
}
