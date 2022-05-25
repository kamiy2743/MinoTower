using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace MT.PlayScreen.States
{
    public class ContinueState : MonoBehaviour, IState
    {
        [SerializeField] private InitializeState _initializeState;

        void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Enter()
        {
            gameObject.SetActive(true);
            ToNext();
        }

        private void ToNext()
        {
            gameObject.SetActive(false);
            _initializeState.Enter();
        }
    }
}
