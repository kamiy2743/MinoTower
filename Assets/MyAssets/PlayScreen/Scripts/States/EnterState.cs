using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class EnterState : MonoBehaviour, IState
    {
        [SerializeField] private GameObject _playScreenObject;
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void Enter()
        {
            _playScreenObject.SetActive(true);
            _nextState = _nextStateObject.GetComponent<IState>();
            _nextState.Enter();
        }
    }
}
