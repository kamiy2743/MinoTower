using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MT.Util;

namespace Mt.TopScreen.States
{
    public class ToPlayScreenState : MonoBehaviour, IState
    {
        [SerializeField] private MT.PlayScreen.States.EnterState _playScreenEnterState;

        public void Enter()
        {
            gameObject.SetActive(true);
            ToNext();
        }

        private void ToNext()
        {
            gameObject.SetActive(false);
            _playScreenEnterState.Enter();
        }
    }
}
