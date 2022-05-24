using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;

namespace MT.PlayScreen
{
    public class MainLoopEndState : MonoBehaviour, IState
    {
        [SerializeField] private GameObject _nextState;
        public IState NextState { get; private set; }
        public void Enter()
        {
            Exit();
        }
        public void Exit()
        {
            NextState.Enter();
        }

        void Awake()
        {
            NextState = _nextState.GetComponent<IState>();
        }
    }
}
