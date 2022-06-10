using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MT.SelectMatchScreen
{
    public class EntryState : MonoBehaviour, IState, IStaticAwake
    {
        [SerializeField] private GameObject _nextStateObject;

        private IState _nextState;

        public void StaticAwake()
        {
            _nextState = _nextStateObject.GetComponent<IState>();
        }

        public void Enter()
        {
            _nextState.Enter();
        }
    }
}
