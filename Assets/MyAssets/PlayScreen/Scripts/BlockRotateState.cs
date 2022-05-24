using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;
using MT.Inputs;

namespace MT.PlayScreen
{
    public class BlockRotateState : MonoBehaviour, IState
    {
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private GameObject _nextState;
        public IState NextState { get; private set; }
        public void Enter() { }
        public void Exit() { }

        void Awake()
        {
            NextState = _nextState.GetComponent<IState>();
        }

        void Update()
        {
            if (_playerInput.RotateBlock())
            {

            }
        }
    }
}
