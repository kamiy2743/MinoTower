using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class EntryState : MonoBehaviourPunCallbacks, IState, IStaticAwake
    {
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private GameObject _nextStateObject;

        [Header("初期化対象")]
        [SerializeField] private RandomProvider _randomProvider;
        [SerializeField] private PlayerTurnProvider _playerTurnProvider;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ScreenScroller _screenScroller;
        [SerializeField] private ResultUI _resultUI;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public async void Enter()
        {
            await Fader.Instance.FadeOut(0);
            await Initialize();

            await Fader.Instance.FadeIn(_fadeInDuration);
            _nextState.Enter();
        }

        private async UniTask Initialize()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                var seed = (int)System.DateTime.Now.Ticks;
                photonView.RPC(nameof(RandomInitialize), RpcTarget.All, seed);
            }

            _blockStore.Initialize();
            _resultUI.Initialize();
            await _rotateButton.Hide(0);
            await _screenScroller.Initialize();
            await _playerTurnProvider.Initialize();
        }

        // TODO ここに書くな
        [PunRPC]
        private void RandomInitialize(int seed)
        {
            _randomProvider.RandomForBlock = new CustomRandom(seed);
        }
    }
}
