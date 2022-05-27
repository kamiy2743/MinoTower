using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.Systems;
using MT.Blocks;

namespace MT.Screens.PlayScreen.States
{
    public class BlockControllState : MonoBehaviour, IState
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private ActiveBlockProvider _ativeBlockProvider;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;
        private Block _activeBlock => _ativeBlockProvider.Get();

        private bool _isActive = false;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            _isActive = true;
        }

        public void ToNext()
        {
            _isActive = false;
            _nextState.Enter();
        }

        void Update()
        {
            if (!_isActive) return;

            if (_playerInput.RotateBlock())
            {
                _activeBlock.Rotate();
            }

            if (_playerInput.MoveBlock())
            {
                var pos = _activeBlock.transform.position;
                pos.x = _playerInput.PointerPosition().x;
                _activeBlock.transform.position = pos;
            }

            if (_playerInput.DropBlock())
            {
                ToNext();
            }
        }
    }
}
