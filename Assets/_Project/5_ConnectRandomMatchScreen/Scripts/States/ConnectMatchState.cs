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

        private IConnectMatch _connectRandomMatch;

        public void StaticStart()
        {
            _backButton.AddListener(async () =>
            {
                await _connectRandomMatch.Disconnect();
                ToNext(_toSelectMatchScreenState);
            });
        }

        public async void Enter()
        {
            _backButton.SetIsListened(true);

            if (_connectRandomMatch != null)
            {
                await _connectRandomMatch.Disconnect();
            }
            _connectRandomMatch = new ConnectRandomMatch();

            var success = await _connectRandomMatch.TryConnect();

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
