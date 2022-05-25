using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ExitState : MonoBehaviour, IState
    {
        [SerializeField] private MT.TopScreen.States.EnterState _topScreenEnterState;

        public void Enter()
        {
            gameObject.SetActive(true);
            _topScreenEnterState.Enter();
        }
    }
}
