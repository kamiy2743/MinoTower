using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.SelectMatchScreen
{
    public class SelectMatchState : MonoBehaviour, IState, IStaticStart
    {
        [Space(20)]
        [SerializeField] private CustomButton _randomMatchButton;

        [Space(20)]
        [SerializeField] private CustomButton _friendMatchButton;
        [SerializeField] private ToConnectFriendMatchScreenState _connectFriendMatchScreenState;

        [Space(20)]
        [SerializeField] private CustomButton _toTopButton;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        public void StaticStart()
        {
            _randomMatchButton.AddListener(() =>
            {
                // ToNext(_randomMatchState);
            });

            _friendMatchButton.AddListener(() =>
            {
                ToNext(_connectFriendMatchScreenState);
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
