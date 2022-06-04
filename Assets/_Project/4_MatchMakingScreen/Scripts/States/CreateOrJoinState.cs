using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.MatchMakingScreen
{
    public class CreateOrJoinState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _createRoomButton;
        [SerializeField] private CreateRoomState _createRoomState;

        [Space(20)]
        [SerializeField] private CustomButton _joinRoomButton;
        [SerializeField] private JoinRoomState _joinRoomState;

        [Space(20)]
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        public void StaticStart()
        {
            _createRoomButton.AddListener(() =>
            {
                Tonext(_createRoomState);
            });

            _joinRoomButton.AddListener(() =>
            {
                Tonext(_joinRoomState);
            });

            _backButton.AddListener(() =>
            {
                Tonext(_toTopScreenState);
            });
        }

        public void Enter()
        {
            _createRoomButton.SetIsListened(true);
            _joinRoomButton.SetIsListened(true);
            _backButton.SetIsListened(true);
        }

        private void Tonext(IState nextState)
        {
            _createRoomButton.SetIsListened(false);
            _joinRoomButton.SetIsListened(false);
            _backButton.SetIsListened(false);

            nextState.Enter();
        }
    }
}
