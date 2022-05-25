using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;
using MT.Blocks;

namespace MT.TopScreen.States
{
    public class InitializeState : MonoBehaviour, IState
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
            Initialize();
            ToNext();
        }

        public void ToNext()
        {
            gameObject.SetActive(false);
            _nextState.Enter();
        }

        private void Initialize()
        {

        }
    }
}

