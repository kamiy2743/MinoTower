using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cysharp.Threading.Tasks;

namespace MT.PlayScreen.Multi
{
    public class ResultState : MonoBehaviour, IState, IStaticStart
    {
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

        private PlayerTurnAccessor _playerTurnAccessor = new PlayerTurnAccessor();
        private CurrentMatchTypeAccessor _currentMatchTypeAccessor = new CurrentMatchTypeAccessor();
        private FriendMatchRoomNameAccessor _friendMatchRoomNameAccessor = new FriendMatchRoomNameAccessor();

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

        public async void Enter()
        {
            _blockSynchronizer.SetIsSynchronize(false);
            ShowResultUIAsync().Forget();

            await PhotonUtil.DisconnectAsync();

            _continueButton.SetIsListened(true);
            _exitButton.SetIsListened(true);
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
            _currentMatchTypeAccessor.Set(MatchType.None);
            _friendMatchRoomNameAccessor.SetEmpty();

            _toTopScreen.Switch();
        }

        private async UniTask ShowResultUIAsync()
        {
            var roomName = _friendMatchRoomNameAccessor.Get();
            var win = !_playerTurnAccessor.IsMyTurn();
            var (winCount, loseCount) = AddResult(roomName, win);

            _resultUI.SetWinOrLoseText(win);
            _resultUI.SetTotalResultText(winCount, loseCount);

            await UniTask.WhenAll(
                _resultUI.ShowAsync(_resultUIFadeInDuration),
                _rotateButton.HideAsync(_rotateButtonFadeOutDuration)
            );
        }

        /// <returns>wincount, loseCount</returns>
        private (int, int) AddResult(string roomName, bool win)
        {
            var winKey = roomName + ":win";
            var winCount = SaveDataManager.Load(winKey, 0) + (win ? 1 : 0);
            var loseKey = roomName + ":lose";
            var loseCount = SaveDataManager.Load(loseKey, 0) + (!win ? 1 : 0);

            SaveDataManager.Save<int>(winKey, winCount);
            SaveDataManager.Save<int>(loseKey, loseCount);

            return (winCount, loseCount);
        }
    }
}

