using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.ConnectRandomMatchScreen
{
    public class ConnectMatchState : MonoBehaviour, IState, IStaticStart
    {
        [Header("マッチ選択画面に遷移")]
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private float _closeDuration;
        [SerializeField] private float _openDuration;

        [Space(20)]
        [SerializeField] private SwitchScreenHelper _toMultiPlayScreen;

        private RandomMatchMaker _matchMaker;

        public void StaticStart()
        {
            _backButton.AddListener(() =>
            {
                ToSelectMatchScreen();
            });
        }

        public void Enter()
        {
            _backButton.SetIsListened(true);
            ConnectMatchAsync().Forget();
        }

        private void OnExit()
        {
            _backButton.SetIsListened(false);
        }

        private async UniTask ConnectMatchAsync()
        {
            _matchMaker = new RandomMatchMaker();
            var success = await _matchMaker.JoinRoomAsync();
            if (!success) return;

            Debug.Log("マッチ成功");
            ToMultiPlayScreen();
        }

        private async void ToSelectMatchScreen()
        {
            OnExit();

            var tasks = new List<UniTask>();

            tasks.Add(Fader.Instance.FadeOutAsync(_closeDuration));

            if (_matchMaker != null)
            {
                tasks.Add(_matchMaker.CancelAsync());
            }

            await UniTask.WhenAll(tasks);

            ScreenSwitcher.Instance.Switch(ScreenType.SelectMatch, 0, _openDuration);
        }

        private void ToMultiPlayScreen()
        {
            OnExit();
            _toMultiPlayScreen.Switch();
        }
    }
}
