using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private MainLoopStartState _startState;
        [SerializeField] private Initializer _initializer;

        public void Enter()
        {
            _initializer.Execute();
            _startState.Enter();
        }
    }
}
