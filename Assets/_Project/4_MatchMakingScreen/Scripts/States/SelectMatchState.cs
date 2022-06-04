using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.MatchMakingScreen
{
    public class SelectMatchState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private SelectMatchUI _selectMatchUI;
        [SerializeField] private float _fadeDuration;

        [Space(20)]
        [SerializeField] private CustomButton _randomMatchButton;
        [SerializeField] private RandomMatchState _randomMatchState;

        [Space(20)]
        [SerializeField] private CustomButton _friendMatchButton;
        [SerializeField] private FriendMatchState _friendMatchState;

        [Space(20)]
        [SerializeField] private CustomButton _toTopButton;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        public void StaticStart()
        {
            _randomMatchButton.AddListener(() =>
            {
                Tonext(_randomMatchState);
            });

            _friendMatchButton.AddListener(() =>
            {
                Tonext(_friendMatchState);
            });

            _toTopButton.AddListener(() =>
            {
                Tonext(_toTopScreenState);
            });
        }

        public async void Enter()
        {
            _randomMatchButton.SetIsListened(true);
            _friendMatchButton.SetIsListened(true);
            _toTopButton.SetIsListened(true);

            await _selectMatchUI.Show(_fadeDuration);
        }

        private async void Tonext(IState nextState)
        {
            _randomMatchButton.SetIsListened(false);
            _friendMatchButton.SetIsListened(false);
            _toTopButton.SetIsListened(false);

            await _selectMatchUI.Hide(_fadeDuration);
            nextState.Enter();
        }
    }
}
