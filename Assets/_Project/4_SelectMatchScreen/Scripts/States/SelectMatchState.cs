using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.SelectMatchScreen
{
    public class SelectMatchState : MonoBehaviour, IState, IStaticStart
    {
        [Space(20)]
        [SerializeField] private CustomButton _randomMatchButton;
        [SerializeField] private SwitchScreenHelper _toConnectRadnomMatchScreen;

        [Space(20)]
        [SerializeField] private CustomButton _friendMatchButton;
        [SerializeField] private SwitchScreenHelper _toConnectFriendMatchScreen;

        [Space(20)]
        [SerializeField] private CustomButton _toTopButton;
        [SerializeField] private SwitchScreenHelper _toTopScreen;

        public void StaticStart()
        {
            _randomMatchButton.AddListener(() =>
            {
                SwitchScreen(_toConnectRadnomMatchScreen);
            });

            _friendMatchButton.AddListener(() =>
            {
                SwitchScreen(_toConnectFriendMatchScreen);
            });

            _toTopButton.AddListener(() =>
            {
                SwitchScreen(_toTopScreen);
            });
        }

        public void Enter()
        {
            _randomMatchButton.SetIsListened(true);
            _friendMatchButton.SetIsListened(true);
            _toTopButton.SetIsListened(true);
        }

        private void SwitchScreen(SwitchScreenHelper switchScreenHelper)
        {
            _randomMatchButton.SetIsListened(false);
            _friendMatchButton.SetIsListened(false);
            _toTopButton.SetIsListened(false);

            switchScreenHelper.Switch();
        }
    }
}
