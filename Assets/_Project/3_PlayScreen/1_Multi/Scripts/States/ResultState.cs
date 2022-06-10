using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Multi
{
    public class ResultState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private TryConnectRoomNameProvider _tryConnectRoomNameProvider;
        [SerializeField] private BlockSynchronizer _blockSynchronizer;

        [Space(20)]
        [SerializeField] private ResultUI _resultUI;
        [SerializeField] private float _resultUIFadeInDuration;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private float _rotateButtonFadeOutDuration;

        [Space(20)]
        [SerializeField] private CustomButton _continueButton;
        [SerializeField] private ContinueState _continueState;

        [Space(20)]
        [SerializeField] private CustomButton _exitButton;
        [SerializeField] private SwitchScreenHelper _toTopScreen;

        private PlayerTurnProvider _playerTurnProvider = new PlayerTurnProvider();

        public void StaticStart()
        {
            _continueButton.AddListener(() =>
            {
                ToContinueState();
            });

            _exitButton.AddListener(() =>
            {
                ToTopScreen();
            });
        }

        public void Enter()
        {
            PhotonNetwork.LeaveRoom();
            _blockSynchronizer.SetIsSynchronize(false);

            _continueButton.SetIsListened(true);
            _exitButton.SetIsListened(true);

            ShowResultUIAsync().Forget();
        }

        private void OnExit()
        {
            _continueButton.SetIsListened(false);
            _exitButton.SetIsListened(false);
        }

        private void ToContinueState()
        {
            OnExit();
            _continueState.Enter();
        }

        private void ToTopScreen()
        {
            OnExit();
            _tryConnectRoomNameProvider.SetEmpty();
            _toTopScreen.Switch();
        }

        private async UniTask ShowResultUIAsync()
        {
            _resultUI.SetWinOrLoseText(!_playerTurnProvider.IsMyTurn());
            _resultUI.SetTotalResultText(1, 5);

            await UniTask.WhenAll(
                _resultUI.ShowAsync(_resultUIFadeInDuration),
                _rotateButton.HideAsync(_rotateButtonFadeOutDuration)
            );
        }
    }
}

