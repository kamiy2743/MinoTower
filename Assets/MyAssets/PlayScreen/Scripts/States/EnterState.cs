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

        void Awake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            _playScreenObject.SetActive(true);
            ToNext();
        }

        private void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }
    }
}
