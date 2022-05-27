using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Screens.PlayScreen.Inputs;
using MT.Blocks;

namespace MT.Screens.PlayScreen.States
{
    public class BlockControllState : MonoBehaviour, IState
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private BlockSpawnState _spawnState;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;
        private Block _spawnedBlock => _spawnState.SpawnedBlock;

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
                _spawnedBlock.Rotate();
            }

            if (_playerInput.MoveBlock())
            {
                var pos = _spawnedBlock.transform.position;
                pos.x = _playerInput.PointerPosition().x;
                _spawnedBlock.transform.position = pos;
            }

            if (_playerInput.DropBlock())
            {
                ToNext();
            }
        }
    }
}
