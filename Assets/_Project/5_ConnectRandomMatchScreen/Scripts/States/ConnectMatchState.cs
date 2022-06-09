using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.ConnectRandomMatchScreen
{
    public class ConnectMatchState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private float _fadeOutDuration;
        [SerializeField] private SwitchScreenState _toSelectMatchScreenState;

        [Space(20)]
        [SerializeField] private SwitchScreenState _toMultiPlayScreenState;

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

        private async UniTask ConnectMatchAsync()
        {
            _matchMaker = new RandomMatchMaker();
            var success = await _matchMaker.TryJoinAsync();
            if (!success) return;

            Debug.Log("マッチ成功");
            ToMultiPlayScreen();
        }

        private async void ToSelectMatchScreen()
        {
            _backButton.SetIsListened(false);

            var tasks = new List<UniTask>(2);

            tasks.Add(Fader.Instance.FadeOutAsync(_fadeOutDuration));

            if (_matchMaker != null)
            {
                tasks.Add(_matchMaker.CancelAsync());
            }

            await UniTask.WhenAll(tasks);

            _toSelectMatchScreenState.Enter();
        }

        private async void ToMultiPlayScreen()
        {
            _backButton.SetIsListened(false);

            await Fader.Instance.FadeOutAsync(_fadeOutDuration);
            _toMultiPlayScreenState.Enter();
        }
    }
}
