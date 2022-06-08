using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.SelectMatchScreen
{
    public class SelectMatchState : MonoBehaviour, IState, IStaticStart
    {
        [Space(20)]
        [SerializeField] private CustomButton _randomMatchButton;
        [SerializeField] private SwitchScreenState _toConnectRadnomMatchScreenState;

        [Space(20)]
        [SerializeField] private CustomButton _friendMatchButton;
        [SerializeField] private SwitchScreenState _toConnectFriendMatchScreenState;

        [Space(20)]
        [SerializeField] private CustomButton _toTopButton;
        [SerializeField] private SwitchScreenState _toTopScreenState;

        public void StaticStart()
        {
            _randomMatchButton.AddListener(() =>
            {
                ToNext(_toConnectRadnomMatchScreenState);
            });

            _friendMatchButton.AddListener(() =>
            {
                ToNext(_toConnectFriendMatchScreenState);
            });

            _toTopButton.AddListener(() =>
            {
                ToNext(_toTopScreenState);
            });
        }

        public void Enter()
        {
            _randomMatchButton.SetIsListened(true);
            _friendMatchButton.SetIsListened(true);
            _toTopButton.SetIsListened(true);
        }

        private void ToNext(IState nextState)
        {
            _randomMatchButton.SetIsListened(false);
            _friendMatchButton.SetIsListened(false);
            _toTopButton.SetIsListened(false);

            nextState.Enter();
        }
    }
}
