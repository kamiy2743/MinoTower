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
            await Fader.Instance.FadeOutAsync(0);
            await InitializeAsync();

            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC(nameof(ToNext), RpcTarget.All);
            }
        }

        [PunRPC]
        private async void ToNext()
        {
            await Fader.Instance.FadeInAsync(_fadeInDuration);
            _nextState.Enter();
        }

        private async UniTask InitializeAsync()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                var seed = (int)System.DateTime.Now.Ticks;
                photonView.RPC(nameof(RandomInitialize), RpcTarget.All, seed);
            }

            PhotonNetwork.SendRate = 60;
            PhotonNetwork.SerializationRate = 60;

            _blockStore.Initialize();
            _resultUI.HideAsync(0).Forget();
            _screenScroller.Initialize();
            _rotateButton.HideAsync(0).Forget();
            await _playerTurnProvider.InitializeAsync();
        }

        [PunRPC]
        private void RandomInitialize(int seed)
        {
            _randomProvider.RandomForBlock = new CustomRandom(seed);
        }
    }
}
