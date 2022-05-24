using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.State;

namespace MT.PlayScreen
{
    public class MainLoopEndState : MonoBehaviour, IState
    {
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            ToNext();
        }

        public void ToNext()
        {
            _nextState.Enter();
        }
    }
}
