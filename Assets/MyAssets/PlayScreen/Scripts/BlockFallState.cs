using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;

namespace MT.PlayScreen
{
    public class BlockFallState : MonoBehaviour, IState
    {
        [SerializeField] private BlockSpawnState _spawnState;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            _spawnState.SpawnedBlock.StartFall();
            ToNext();

        }

        public void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }
    }
}

