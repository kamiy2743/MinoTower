using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.TopScreen
{
    public class WaitForPlayerActionState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _singlePlayButton;
        [SerializeField] private SwitchScreenState _toSinglePlayScreenState;

        [Space(20)]
        [SerializeField] private CustomButton _multiPlayButton;
        [SerializeField] private SwitchScreenState _toSelectMatchScreenState;

        [Space(20)]
        [SerializeField] private CustomButton _optionButton;
        [SerializeField] private SwitchScreenState _toOptionScreenState;

        public void StaticStart()
        {
            _singlePlayButton.AddListener(() =>
            {
                ToNext(_toSinglePlayScreenState);
            });

            _multiPlayButton.AddListener(() =>
            {
                ToNext(_toSelectMatchScreenState);
            });

            _optionButton.AddListener(() =>
            {
                ToNext(_toOptionScreenState);
            });
        }

        public void Enter()
        {
            _singlePlayButton.SetIsListened(true);
            _multiPlayButton.SetIsListened(true);
            _optionButton.SetIsListened(true);
        }

        private void ToNext(IState nextState)
        {
            _singlePlayButton.SetIsListened(false);
            _multiPlayButton.SetIsListened(false);
            _optionButton.SetIsListened(false);

            nextState.Enter();
        }
    }
}
