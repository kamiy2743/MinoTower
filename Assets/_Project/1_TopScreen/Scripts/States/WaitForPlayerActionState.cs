using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.TopScreen
{
    public class WaitForPlayerActionState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _singlePlayButton;
        [SerializeField] private SwitchScreenHelper _toSinglePlayScreen;

        [Space(20)]
        [SerializeField] private CustomButton _multiPlayButton;
        [SerializeField] private SwitchScreenHelper _toSelectMatchScreen;

        [Space(20)]
        [SerializeField] private CustomButton _optionButton;
        [SerializeField] private SwitchScreenHelper _toOptionScreen;

        public void StaticStart()
        {
            _singlePlayButton.AddListener(() =>
            {
                SwitchScreen(_toSinglePlayScreen);
            });

            _multiPlayButton.AddListener(() =>
            {
                SwitchScreen(_toSelectMatchScreen);
            });

            _optionButton.AddListener(() =>
            {
                SwitchScreen(_toOptionScreen);
            });
        }

        public void Enter()
        {
            _singlePlayButton.SetIsListened(true);
            _multiPlayButton.SetIsListened(true);
            _optionButton.SetIsListened(true);
        }

        private void SwitchScreen(SwitchScreenHelper switchScreenHelper)
        {
            _singlePlayButton.SetIsListened(false);
            _multiPlayButton.SetIsListened(false);
            _optionButton.SetIsListened(false);

            switchScreenHelper.Switch();
        }
    }
}
