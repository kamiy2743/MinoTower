using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class MainLoopEndState : MonoBehaviour, IState
    {
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
            ToNext();
        }

        public void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }
    }
}
