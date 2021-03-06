using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MT.PlayScreen
{
    public class BlockControllState : MonoBehaviourPunCallbacks, IState, IStaticAwake, IStaticStart
    {
        [SerializeField] private PlayScreenConfig _config;

        [Space(20)]
        [SerializeField] private ActiveBlockProvider _ativeBlockProvider;

        [Space(20)]
        [SerializeField] private DropBlockEvent _dropBlockEvent;
        [SerializeField] private MoveBlockEvent _moveBlockEvent;
        [SerializeField] private PointerPositionProvider _pointerPositionProvider;
        [SerializeField] private RotateButton _rotateButton;

        [Space(20)]
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;
        private Block _activeBlock => _ativeBlockProvider.Get();

        private PlayerTurnAccessor _playerTurnAccessor = new PlayerTurnAccessor();

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void StaticStart()
        {
            _rotateButton.AddListener(async () =>
            {
                if (!_playerTurnAccessor.IsMyTurn()) return;

                _rotateButton.SetIsListened(false);
                AudioPlayer.Instance.PlaySE(_config.OnRotateSE);
                await _activeBlock.RotateAsync();
                _rotateButton.SetIsListened(true);
            });

            _moveBlockEvent.AddListener(() =>
            {
                if (!_playerTurnAccessor.IsMyTurn()) return;

                var pos = _activeBlock.transform.position;
                pos.x = _pointerPositionProvider.Get().x;
                _activeBlock.transform.position = pos;
            });

            _dropBlockEvent.AddListener(() =>
            {
                if (!_playerTurnAccessor.IsMyTurn()) return;

                photonView.RPC(nameof(ToNext), RpcTarget.All);
            });
        }

        public void Enter()
        {
            if (_playerTurnAccessor.IsMyTurn())
            {
                _moveBlockEvent.SetIsListened(true);
                _dropBlockEvent.SetIsListened(true);
                _rotateButton.SetIsListened(true);

                photonView.RequestOwnership();
            }
        }

        [PunRPC]
        public void ToNext()
        {
            _moveBlockEvent.SetIsListened(false);
            _dropBlockEvent.SetIsListened(false);
            _rotateButton.SetIsListened(false);

            _nextState.Enter();
        }
    }
}
