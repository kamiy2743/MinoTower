using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;

namespace MT.PlayScreen
{
    public class BlockFallState : MonoBehaviour, IState
    {
        [SerializeField] private BlockSpawnState _spawnState;
        [SerializeField] private GameObject _nextState;
        public IState NextState { get; private set; }
        public void Enter()
        {
            gameObject.SetActive(true);
            _spawnState.SpawnedBlock.StartFall();
            Exit();
        }
        public void Exit()
        {
            gameObject.SetActive(false);
            NextState.Enter();
        }

        void Awake()
        {
            NextState = _nextState.GetComponent<IState>();
            gameObject.SetActive(false);
        }
    }
}

