using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace MT.ConnectRandomMatchScreen
{
    public class ConnectMatchState : MonoBehaviour, IState, IStaticStart
    {
        [SerializeField] private CustomButton _backButton;
        [SerializeField] private SwitchScreenState _toSelectMatchScreenState;

        [Space(20)]
        [SerializeField] private SwitchScreenState _toMultiPlayScreenState;

        private RandomMatchMaker _matchMaker;

        public void StaticStart()
        {
            _backButton.AddListener(async () =>
            {
                await _matchMaker.Disconnect();
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

        private void ToNext(IState nextState)
        {
            _backButton.SetIsListened(false);

            nextState.Enter();
        }
    }
}
