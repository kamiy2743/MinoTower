using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class ResultState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private PlayerTurnProvider _playerTurnProvider;

        [Space(20)]
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private float _fadeDuration;

        [Space(20)]
        [SerializeField] private CustomButton _continueButton;
        [SerializeField] private ContinueState _continueState;

        [Space(20)]
        [SerializeField] private CustomButton _exitButton;
        [SerializeField] private ToTopScreenState _toTopScreenState;

        public void StaticStart()
        {
            _continueButton.AddListener(() =>
            {
                ToNext(_continueState);
            });

            _exitButton.AddListener(() =>
            {
                PhotonNetwork.LeaveRoom();
                ToNext(_toTopScreenState);
            });
        }

        public void Enter()
        {
            _continueButton.SetIsListened(true);
            _exitButton.SetIsListened(true);

            ShowResultUIAsync();
        }

        private void ToNext(IState nextState)
        {
            _continueButton.SetIsListened(false);
            _exitButton.SetIsListened(false);

            nextState.Enter();
        }

        private async void ShowResultUIAsync()
        {
            _resultUI.ShowAsync();
            _resultUI.SetWinOrLoseText(!_playerTurnProvider.IsMyTurn());
            _resultUI.SetTotalResultText(1, 5);

            await _rotateButton.HideAsync(_fadeDuration);
        }
    }
}

