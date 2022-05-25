using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private InitializeState _initializeState;

        public void Enter()
        {
            _initializeState.Enter();
        }
    }
}
