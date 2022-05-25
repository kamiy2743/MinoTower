using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class BlockFallState : MonoBehaviour, IState
    {
        [SerializeField] private BlockSpawnState _spawnState;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            _spawnState.SpawnedBlock.StartFall();
            ToNext();
        }

        public void ToNext()
        {
            _nextState.Enter();
        }
    }
}

