using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Photon.Pun;

namespace MT.PlayScreen.Multi
{
    public class PreInitializeState : MonoBehaviourPunCallbacks, IPreInitializeStateAsync
    {
        [Header("初期化対象")]
        [SerializeField] private RandomProvider _randomProvider;
        [SerializeField] private BlockStore _blockStore;
        [SerializeField] private RotateButton _rotateButton;
        [SerializeField] private ScreenScroller _screenScroller;
        [SerializeField] private ResultUI _resultUI;

        private PlayerTurnAccessor _playerTurnAccessor = new PlayerTurnAccessor();

        public async UniTask Enter()
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
            await _playerTurnAccessor.InitializeAsync();
        }

        [PunRPC]
        private void RandomInitialize(int seed)
        {
            _randomProvider.RandomForBlock = new CustomRandom(seed);
        }
    }
}
