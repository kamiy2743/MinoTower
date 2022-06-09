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
                ToNext(_toSelectMatchScreenState);
            });
        }

        public async void Enter()
        {
            _backButton.SetIsListened(true);

            if (_matchMaker != null)
            {
                await _matchMaker.Disconnect();
            }
            _matchMaker = new RandomMatchMaker();

            var success = await _matchMaker.TryConnectAsync();

            //TODO 失敗した時の遷移
            if (success)
            {
                Debug.Log("マッチ成功");
                ToNext(_toMultiPlayScreenState);
            }
        }

        private async void ToNext(IState nextState)
        {
            _backButton.SetIsListened(false);

            var tasks = new List<UniTask>(2);

            tasks.Add(Fader.Instance.FadeOutAsync(_fadeOutDuration));

            if (_matchMaker != null)
            {
                tasks.Add(_matchMaker.Disconnect());
            }

            await UniTask.WhenAll(tasks);

            nextState.Enter();
        }
    }
}
