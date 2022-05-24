using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;
using MT.Inputs;
using MT.Blocks;

namespace MT.PlayScreen
{
    public class BlockControllState : MonoBehaviour, IState
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private BlockSpawnState _spawnState;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;
        private Block _spawnedBlock => _spawnState.SpawnedBlock;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);

        }

        public void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }


        void Update()
        {
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
